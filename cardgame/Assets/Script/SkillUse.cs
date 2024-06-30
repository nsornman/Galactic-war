using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUse : MonoBehaviour
{
    public GameObject SkillRelease;
    [Header("Self-Assignable")]
    public DataTransform carddata;
    public SkillCard skillCard;
    public void Awake(){
        carddata = FindObjectOfType<DataTransform>();
    }

    public void Update()
    {
        SetSkill();
    }

    public void SetSkill(){
        if(carddata.Skill){
            //Debug.Log("holding construction card");
            skillCard = carddata.cardusing as SkillCard;
        }else{
            skillCard = null;
        }
    }

    public void OnUse(){
        if(skillCard != null){
            skillCard.OnUse(SkillRelease.transform);
            carddata.Used = true;
        }
    }
}
