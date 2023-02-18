using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTriger : MonoBehaviour
{
    public BattleState battleState = BattleState.CHILL;
    public BattleSystem battleSystem;

   void OnTriggerEnter2D(Collider2D collider)
   {
        if(collider.gameObject.tag == "Player")
            Debug.Log(battleSystem.state);
            battleState = BattleState.START;
            battleSystem.state = battleState;
            battleSystem.StartCoroutine(battleSystem.SetupBattle());
   }
}
