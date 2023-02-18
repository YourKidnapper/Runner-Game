using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTriger : MonoBehaviour
{
    public BattleState battleState = BattleState.CHILL;

    public Collider2D startBattle;

   void  Update()
   {
        if(startBattle)
        {
            //Debug.Log("Battle is started!");
            battleState = BattleState.START;
        }
   }
}
