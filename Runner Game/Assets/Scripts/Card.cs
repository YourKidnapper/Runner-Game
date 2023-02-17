using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Runner Game/Card", order = 0)]
public class Card : ScriptableObject {

    public new string name;
    public string stat;
    public Sprite artwork;
}

