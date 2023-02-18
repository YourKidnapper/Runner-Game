using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Slider hpSlider;
    public Text damage;
    public Text defence;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
        damage.text = unit.damage.ToString();
        defence.text = unit.defence.ToString();
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }

    public void clearHUD(Unit unit)
    {
        nameText.text = "";
        hpSlider.value = 0;
        damage.text = "";
        defence.text = "";
    }
}
