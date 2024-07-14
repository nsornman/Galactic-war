using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUse : MonoBehaviour
{
    public GameObject SkillRelease;
    [Header("Self-Assignable")]
    public DataTransform carddata;
    public SkillCard skillCard;

    public void Update()
    {
        SetSkill();
    }

    public void SetSkill(){
        if (!carddata.Skill)
        {
            skillCard = null;
        }
        else
        {
            //Debug.Log("holding construction card");
            skillCard = carddata.cardusing as SkillCard;
        }
    }

    public void OnUse(){
        if(skillCard != null){
            skillCard.OnUse(SkillRelease.transform);
            carddata.Used = true;
        }
    }
}
