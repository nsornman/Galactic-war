using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Card/Skill Card/Passive", fileName ="New Active Skill card")]
public class Passiveskillcard : SkillCard
{
    public PassiveType passivetype = new PassiveType();
    public Affective waysToAffected = new Affective();
    [HideInInspector] public Player player;
    public override void Awake(){
        Skilltype = Skilltype.Passive;
        base.Awake();
    }

    public override void Use()
    {
        if(this.passivetype == PassiveType.Increase){
            if(waysToAffected == Affective.material){
                player.GainMultiplier = 2f;
            }if(waysToAffected == Affective.shuffle){
                //Action
            }
        }
        if(this.passivetype == PassiveType.Decrease){
            if(waysToAffected == Affective.material){
                player.CostMultiplier = 0.5f;
            }
        }
    }
}
public enum PassiveType{
    Increase,
    Decrease
}

public enum Affective{
    material,
    shuffle
}
