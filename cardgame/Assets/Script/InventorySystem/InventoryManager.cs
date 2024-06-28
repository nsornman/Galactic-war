using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Skillslot[] skillslots;
    public Contructslot[] constructslots;
    public CardItem[] card;
    public SkillCard[] SC;
    public ConstructionCard[] CC;
    void Start()
    {
        // skillslots = FindObjectsOfType<Skillslot>();
        // constructslots = FindObjectsOfType<Contructslot>();
        if (SC.Length == 0 || CC.Length == 0)
        {
            Debug.LogError("SkillCard or ConstructionCard arrays are not populated!");
        }
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            AddSkillitem(SC[randomSCindice()]);
        }
        if(Input.GetKeyDown(KeyCode.D)){
            AddConstructitem(CC[randomCCindice()]);
        }
        if(Input.GetKeyDown(KeyCode.Tab)){
            if(Checkfullslot()){
                Debug.Log("All slot is full");
            }else{
                Debug.Log("Some slot is not full");
            }
        }
        if(Input.GetKeyDown(KeyCode.E)){
            EmptyAllSlot();
        }
    }

    public void StartCard(int ConstructCard ,int SkillCard){
        for(int i = 0;i< ConstructCard;i++){
            AddConstructitem(CC[randomCCindice()]);
        }
        for(int i= 0;i< SkillCard;i++){
            AddSkillitem(SC[randomSCindice()]);
        }
        Debug.Log("HI");
    }
    public int randomSCindice(){
        if (SC.Length == 0)
        {
            Debug.Log("No cards available");
        }
        return Random.Range(0, SC.Length);
    } 
    public int randomCCindice(){
        if (CC.Length == 0)
        {
            Debug.Log("No cards available");
        }
        return Random.Range(0, CC.Length);
    } 

    public void AddSkillitem(CardItem card){
        string cardname = card.CardName;
        Sprite cardsprite = card.Cardsprite;
        for (int i = 0; i < skillslots.Length; i++)
        {
            if(!skillslots[i].isfull){
                skillslots[i].Additem(cardname , cardsprite, card);
                return;
            }
        }
    }
    public void AddConstructitem(CardItem card){
        string cardname = card.CardName;
        Sprite cardsprite = card.Cardsprite;
        for (int i = 0; i < constructslots.Length; i++)
        {
            if(!constructslots[i].isfull){
                constructslots[i].Additem(cardname , cardsprite, card);
                return;
            }
        }
    }
    public bool Checkfullslot(){
        bool slotfull = true;
        for(int i= 0;i< skillslots.Length;i++){
            if(!skillslots[i].isfull){
                slotfull = false;
            }
        }
        for(int i= 0;i< constructslots.Length;i++){
            if(!constructslots[i].isfull){
                slotfull = false;
            }
        }
        if(slotfull){
            return true;
        }else{
            return false;
        }
    }
    public void DeselectedAllSlot(){
        for (int i = 0; i < skillslots.Length; i++)
        {
            skillslots[i].SelectedPanel.SetActive(false);
            skillslots[i].selected = false;
        }
        for (int i = 0; i < constructslots.Length; i++)
        {
            constructslots[i].SelectedPanel.SetActive(false);
            constructslots[i].selected = false;
        }
    }
    void EmptyAllSlot(){
        for (int i = 0; i < skillslots.Length; i++)
        {
            skillslots[i].Useitem();
        }
        for (int i = 0; i < constructslots.Length; i++)
        {
            constructslots[i].Useitem();
        }
    }

}
