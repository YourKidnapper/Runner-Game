using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battke : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    Unit playerUnit;
    Unit enemyUnit;

    public Text enemyName;
    public Text enemyHp;
    public Text enemyDamage;
    public Text enemyDefense;
    
    public Text playerHp;
    public Text playerDamage;
    public Text playerDefense;


    void SetHUD()
    {
        playerUnit = playerPrefab.GetComponent<Unit>();
        playerHp.text = playerUnit.currentHP.ToString();
        playerDamage.text = playerUnit.damage.ToString();
        playerDefense.text = playerUnit.defense.ToString();

        enemyName.text = enemyUnit.unitName;
        enemyHp.text = enemyUnit.currentHP.ToString();
        enemyDamage.text = enemyUnit.damage.ToString();
        enemyDefense.text = enemyUnit.defense.ToString();
    }
}
