using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public string unitName;
    public bool isArmored;

    public int damage;
    public int defense;

    public int maxHP;
    public int currentHP;

    public bool TakeDamage(int damage, Unit unit)
    {
        if(unit.isArmored == true)
        {
            if(unit.defense > damage)
                return true;
            else
                currentHP -= damage;
        }
        else
        {
            currentHP -= damage;
        }
        if(currentHP <= 0)
            return true;
        else
            return false;
    }
}
