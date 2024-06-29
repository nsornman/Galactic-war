using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using UnityEngine;

public class DataTransform : MonoBehaviour
{
    public Contructslot[] CS;
    public Skillslot[] SS;
    public CardItem cardusing;
    public SkillUse skillUse; 
    public bool Construct,Skill;
    public bool placed = false;
    public bool Used = false;

    void Start()
    {
        SS = FindObjectsOfType<Skillslot>();
        CS = FindObjectsOfType<Contructslot>();
    }
    void Update()
    {
        GetSelectedSlot();
        GetCardtype();
        CheckPlacing();
        CheckUsing();
        CheckSelected();
    }

    public void GetSelectedSlot(){
        if(HaveSelected()){
            for (int i = 0; i < CS.Length; i++)
            {
                if (CS[i].selected && CS[i].isfull)
                {
                    cardusing = CS[i].card;
                    return; // Exit the method once the selected card is found
                }
            }

            // Loop through Skillslots
            for (int i = 0; i < SS.Length; i++)
            {
                if (SS[i].selected && SS[i].isfull)
                {
                    cardusing = SS[i].card;
                    return; // Exit the method once the selected card is found
                }
            }
        }
        else{
            cardusing = null;
        }
        
    }
    public bool HaveSelected(){
        for (int i = 0; i < CS.Length; i++)
        {
            if(CS[i].selected) return true;
        }
        for (int i = 0; i < SS.Length; i++)
        {
            if(SS[i].selected) return true;
        }
        return false;
    }

    public void GetCardtype(){
        if (cardusing != null) { // Check if cardusing is not null
            if (cardusing.Type == itemtype.Contructionitem){
                Construct = true;
                Skill = false;
            } else if (cardusing.Type == itemtype.Skillitem){
                Skill = true;
                Construct = false;
            }
        } else {
            // Handle the case when cardusing is null
            Construct = false;
            Skill = false;
        }
    }
    public void CheckPlacing(){
        if(HaveSelected() && placed){
            for (int i = 0; i < CS.Length; i++)
            {
                if (CS[i].selected && CS[i].isfull)
                {
                    CS[i].Useitem();
                    placed = false;
                    return; // Exit the method once the selected card is found
                }
            }
        }
    }
    public void CheckUsing(){
        if(HaveSelected() && Used){
            for (int i = 0; i < SS.Length; i++)
            {
                if (SS[i].selected && SS[i].isfull)
                {
                    SS[i].Useitem();
                    Used = false;
                    return; // Exit the method once the selected card is found
                }
            }
        }
    }
    public void CheckSelected(){
        if(HaveSelected() && cardusing.Type == itemtype.Skillitem){
            skillUse.gameObject.SetActive(true);
        }else{
            skillUse.gameObject.SetActive(false);
        }
    }
}
