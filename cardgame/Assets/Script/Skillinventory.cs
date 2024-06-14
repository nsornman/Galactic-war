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
        if(Input.GetKeyDown(KeyCode.Tab)){
            if(Checkfullslot()){
                Debug.Log("All slot is full");
            }else{
                Debug.Log("Some slot is not full");
            }
        }
    }

    public void Additem(CardItem card){
        string cardname = card.CardName;
        Sprite cardsprite = card.Cardsprite;
        for (int i = 0; i < cardslot.Length; i++)
        {
            if(!cardslot[i].isfull){
                cardslot[i].Additem(cardname , cardsprite);
                return;
            }
        }
    }
    public bool Checkfullslot(){
        bool slotfull = true;
        for(int i= 0;i< cardslot.Length;i++){
            if(!cardslot[i].isfull){
                slotfull = false;
            }
        }
        if(slotfull){
            return true;
        }else{
            return false;
        }
    }
}
