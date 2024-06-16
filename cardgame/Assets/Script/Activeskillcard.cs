using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Card/Skill Card/Active" , fileName ="New Active Skill card")]
public class Activeskillcard : SkillCard
{
    public override void Awake()
    {
        Skilltype = Skilltype.Active;
    }
    public override void Use()
    {
        
    }
}
