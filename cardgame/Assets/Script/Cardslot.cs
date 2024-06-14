using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cardslot : MonoBehaviour
{
    //=======Item Data=======//
    private string itemname;
    private Sprite itemimage;
    public bool isfull = false;

    //=====Item Slot=====//
    [SerializeField] private TMP_Text cardname;
    [SerializeField] private Image cardimage;

    public void Additem(string name, Sprite cardsprite){
        this.itemname = name;
        this.itemimage = cardsprite;
        isfull = true;

        cardname.text = itemname.ToString();
        this.cardimage.sprite = itemimage;
    }
}
