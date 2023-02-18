using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Text hp;
    public Text damage;
    public Text defence;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        hp.text = unit.currentHP.ToString();
        damage.text = unit.damage.ToString();
        defence.text = unit.defence.ToString();
    }

    public void SetHP(int newHp)
    {
        hp.text = newHp.ToString();
    }

    public void clearHUD(Unit unit)
    {
        nameText.text = "";
        hp.text = "";
        damage.text = "";
        defence.text = "";
    }
}
