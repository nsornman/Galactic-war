using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="Card/Skill Card" ,fileName ="new Skill card")]
public class SkillCard : CardItem
{
    public void Awake(){
        Type = itemtype.Skillitem;
    }
}
