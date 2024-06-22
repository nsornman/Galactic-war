using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Skillslot : MonoBehaviour , IPointerClickHandler
{
    //=======Item Data=======//
    private string itemname;
    private Sprite itemimage;
    [HideInInspector]public bool isfull = false;
    public CardItem card;
   
    //=====Item Slot=====// 
    [Header("Item Slot")]
    [SerializeField] private TMP_Text cardname;
    [SerializeField] private Image cardimage;
    
    
    public GameObject SelectedPanel;
    public bool selected = false;

    private InventoryManager IM;

    void Start()
    {
        IM = FindObjectOfType<InventoryManager>();
    }
    public void Additem(string name, Sprite cardsprite, CardItem card){
        this.itemname = name;
        this.itemimage = cardsprite;
        isfull = true;
        this.card = card;

        cardname.text = itemname.ToString();
        if(!cardimage.gameObject.activeSelf){
            cardimage.gameObject.SetActive(true);
        }
        this.cardimage.sprite = itemimage;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left){
            OnLeftClick();
        }
        if(eventData.button == PointerEventData.InputButton.Right){
            OnRightClick();
        }
    }

    void OnLeftClick(){
        if (selected)
        {
            // Deselect this slot
            selected = false;
            SelectedPanel.SetActive(false);
        }
        else
        {
            // Deselect all other slots
            IM.DeselectedAllSlot();
            // Select this slot
            selected = true;
            SelectedPanel.SetActive(true);
        }
    }

    void OnRightClick(){
        if(selected){
            Useitem();
            selected = false;
            SelectedPanel.SetActive(false);
        }
    }

    public void Useitem(){
        if(isfull){
            isfull = false;
            Emptyslot();
        }
        if(selected){

            selected = false;
            SelectedPanel.SetActive(false);
        }
    }
    void Emptyslot(){
        this.cardname.text = "Emptycard";
        this.cardimage.gameObject.SetActive(false);
    }
}
