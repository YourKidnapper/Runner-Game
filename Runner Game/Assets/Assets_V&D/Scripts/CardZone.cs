using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZone : MonoBehaviour
{
   public int totalCards = 1;
   public GameObject cardHolder;
   public GameObject[] cards;
   public GameObject curCard;
   public int curCardIndex;
   
   void Start()
   {
      totalCards = cardHolder.transform.childCount;
      cards = new GameObject[totalCards];
      for(int i = 0; i < totalCards; i++) 
      {
         cards[i] = cardHolder.transform.GetChild(i).gameObject;   
      }

   }
   
   void OnMouseEnter()
   {
      Debug.Log("I'm enter");
      transform.position += Vector3.up * 150;      
   }
   
   void OnMouseExit()
   {
      Debug.Log("I'm leave");
      transform.position += Vector3.down * 150;
   }
}
