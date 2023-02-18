using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, ATTACK, DEFEND, PLAYERTURN, ENEMYTURN, WON, LOST, CHILL}

public class BattleSystem : MonoBehaviour
{
    //Audio
    public AudioSource sfxSource;

    //Controller
    public PlayerController controller;

    //GameObjects
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    //Transform
    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    //Text
    public Text battleState;
    public Text turnCounter;

    //Units
    Unit playerUnit;
    Unit enemyUnit;

    private float lastClick;
    

    //Buttons
    public Button dash;

    //HUD
    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public float turns;
    public float currentTurn;

    public CardZone cardZone;
    public BattleState state;


    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    public IEnumerator SetupBattle()
    {
        GameObject playerGO = new GameObject();   
        if(!GameObject.FindGameObjectWithTag("Player"))
        {
            playerGO = Instantiate(playerPrefab, playerBattleStation);
            playerUnit = playerGO.gameObject.GetComponent<Unit>();

            playerHUD.SetHUD(playerUnit);
        }
        playerUnit.IsInBattle(true);

        if(!GameObject.FindGameObjectWithTag("Enemy")){
            GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
            enemyUnit = enemyGO.GetComponent<Unit>();

            enemyHUD.SetHUD(enemyUnit); 
        }
        

        yield return new WaitForSeconds(1f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        state = BattleState.ATTACK;
        sfxSource.Play();
        battleState.text = "You're attacking";
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage, enemyUnit);

        yield return new WaitForSeconds(1f);

        if(isDead)
        {
            state = BattleState.WON;
            enemyHUD.SetHP(enemyUnit.currentHP =  0);
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            enemyHUD.SetHP(enemyUnit.currentHP);

            yield return new WaitForSeconds(1f);
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        battleState.text = "Enemy Turn";
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage, playerUnit);
        
        yield return new WaitForSeconds(1f);

        if(isDead)
        {
            state = BattleState.LOST;
            playerHUD.SetHP(playerUnit.currentHP = 0);
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            playerHUD.SetHP(playerUnit.currentHP);

            yield return new WaitForSeconds(1f);
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        battleState.text = "Battle is over!";

        if(state == BattleState.WON)
        {
            playerUnit.IsInBattle(false);
            turnCounter.text = "";
            turns = 0;
            state = BattleState.CHILL;
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            Destroy(GameObject.FindGameObjectWithTag("Zone"));
            enemyHUD.clearHUD(enemyUnit);

            for(int i = 0; i < cardZone.totalCards; i++)
            {
                cardZone.cards[i].SetActive(true); 
            }

        }
        else if (state == BattleState.LOST)
        {
            battleState.text = "You lost";
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void PlayerTurn()
    {
        playerUnit.isArmored = false;
        playerUnit.isDashed = false;
        turns++;
        turnCounter.text = turns.ToString();
        battleState.text = "Your turn";
        if(currentTurn == 0)
        {
            dash.gameObject.SetActive(true);
        }
        else
        {
            dash.gameObject.SetActive(false);
            currentTurn = currentTurn - 0.5f;
        }
    }

    public void OnAttackButton()
    {
        if(lastClick > (Time.time - 2f)) return;
        lastClick = Time.time;
        if(state != BattleState.PLAYERTURN)
            return;
        
        StartCoroutine(PlayerAttack());
    }

    public void OnDefenceButton()
    {
        if(lastClick > (Time.time - 2f)) return;
        lastClick = Time.time;
        if(state != BattleState.PLAYERTURN)
            return;
        
        StartCoroutine(PlayerDefence());
    }

    public IEnumerator PlayerDefence()
    {
        state = BattleState.DEFEND;
        battleState.text = "You're defending yourself";
        playerUnit.isArmored = true;

        yield return new WaitForSeconds(1f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    public void OnDashButton()
    {
        if(lastClick > (Time.time - 2f)) return;
        lastClick = Time.time;
        if(state != BattleState.PLAYERTURN)
            return;
        if(dash){
            if(state != BattleState.PLAYERTURN)
                return;
            StartCoroutine(PlayerDash());
        }
    }

    public IEnumerator PlayerDash()
    {
        battleState.text = "You're dashed";
        playerUnit.isDashed = true;

        yield return new WaitForSeconds(1f);

        if(dash)
        {
            currentTurn++;
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }
}
