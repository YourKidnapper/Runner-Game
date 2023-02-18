using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBattle : MonoBehaviour
{
    public BattleState battleState;

    public Collider2D startBattle;

   void  Update()
   {
        if(startBattle)
        {
            Debug.Log("Battle is started!");
            battleState = BattleState.START;
        }
   }
}
