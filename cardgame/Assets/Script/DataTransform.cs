using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using UnityEngine;

public class DataTransform : MonoBehaviour
{
    public Contructslot[] CS;
    public Skillslot[] SS;
    public CardItem cardusing;

    void Start()
    {
        SS = FindObjectsOfType<Skillslot>();
        CS = FindObjectsOfType<Contructslot>();
    }
    void Update()
    {
        GetSelectedSlot();
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
}
