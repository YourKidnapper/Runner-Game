using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6.5f;
    public Rigidbody2D player;
    Vector2 movement;
    public bool isInBattle = false;
    private string curState;
    public Animator animator;

    //Animation states
    const string PLAYER_STAY = "Player_Idle";
    const string PLAYER_GO = "Player_Walking";
    const string PLAYER_ATTACK = "Player_Attack";

    public BattleSystem battleSystem;
    public BattleState battleState;

    // Update is called once per frame
    void Update()
    {
        gameObject.tag = "Player";
        movement.x = Input.GetAxisRaw("Horizontal");
    }
    
    void ChangeAnimationState(string newState){
        //stop the same animation from interrupting itself
        if(curState == newState) return;
        //Play the animation
        animator.Play(newState);
        //reassign the current state 
        curState = newState;
    }

    void FixedUpdate()
    {
        if(!isInBattle)
        {
            player.MovePosition(player.position + movement * moveSpeed * Time.fixedDeltaTime);
            if(movement.x != 0)
            {
                ChangeAnimationState(PLAYER_GO);
            }
            else if(movement.x == 0)
            {
                ChangeAnimationState(PLAYER_STAY);
            }
        }
        if(battleSystem.state == BattleState.ATTACK)
        {
            Debug.Log("You're attacking");
            ChangeAnimationState(PLAYER_ATTACK);
        }
        else if (battleSystem.state == BattleState.PLAYERTURN)
        {
            ChangeAnimationState(PLAYER_STAY);
        }
    }

}
