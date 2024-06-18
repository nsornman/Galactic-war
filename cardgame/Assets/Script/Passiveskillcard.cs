using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Card/Skill Card/Passive", fileName ="New Active Skill card")]
public class Passiveskillcard : SkillCard
{
    public override void Awake(){
        Skilltype = Skilltype.Passive;
        base.Awake();
    }

    public override void Use()
    {
        
    }
}
