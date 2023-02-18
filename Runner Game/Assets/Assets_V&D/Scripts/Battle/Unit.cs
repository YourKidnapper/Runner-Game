using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public string unitName;
    public bool isArmored = false;
    public bool isDashed = false;

    public int damage;
    public int defence;

    public int maxHP;
    public int currentHP;
    
    public GameObject enemyPrefab;

    public Transform unitZone;
    public PlayerController controller;

    public bool TakeDamage(int damage, Unit unit)
    {
        if(unit.isDashed == true)
        {
            return false;
        }
        if(unit.isArmored)
        {
            if(unit.defence > damage)
                return false;
            else
            {
                currentHP -= damage - defence;
            }
        }
        else
        {
            currentHP -= damage;
        }
        if(unit.currentHP <= 0)
            return true;
        else
            return false;
    }

    public void IsInBattle(bool state)
    {
        controller.isInBattle = state;
    }

    public void Spawn(Transform zone)
    {
        Instantiate(enemyPrefab, zone);
    }
}
