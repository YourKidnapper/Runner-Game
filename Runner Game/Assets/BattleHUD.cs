using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Text hp;
    public Text damage;
    public Text defense;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        hp.text = unit.currentHP.ToString();
        damage.text = unit.damage.ToString();
        defense.text = unit.defense.ToString();
    }

    public void SetHP(int newHp)
    {
        hp.text = newHp.ToString();
    }
}
