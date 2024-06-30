using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Card/Skill Card" ,fileName ="New Skill Card")]
public class SkillCard : CardItem
{
    public GameObject SkillObject;
    public void Awake(){
        Type = itemtype.Skillitem;
    }
    public void OnUse(Transform SkillRelease){
        Instantiate(SkillObject ,SkillRelease);
    }
}
