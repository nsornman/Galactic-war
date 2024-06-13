using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skillinventory : MonoBehaviour
{
    public Cardslot[] cardslot;
    public CardItem card;
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Additem(card);
        }
    }

    public void Additem(CardItem card){
        string cardname = card.CardName;
        Image cardimage = card.CardImage;
        for (int i = 0; i < cardslot.Length; i++)
        {
            if(!cardslot[i].isfull){
                cardslot[i].Additem(cardname , cardimage);
                return;
            }
        }
    }
}
