using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float Hp;
    public float Defense;
    public float Attack;
    public Text HpCounter;
    // Start is called before the first frame update
    void Start()
    {
        Hp = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Hp > 0){
            HpCounter.text = Hp.ToString();
        }
    }
}
