using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsUpAndDown : MonoBehaviour
{
    public Transform cards;

    void OnMouseEnter()
   {
      cards.position += Vector3.up * 150;      
   }
   
   void OnMouseExit()
   {
      cards.position += Vector3.down * 150;
   }
}
