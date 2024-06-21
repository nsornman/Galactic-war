using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillCard : CardItem
{
    public Skilltype Skilltype = new Skilltype();
    public virtual void Awake(){
        Type = itemtype.Skillitem;
    }
    public abstract void Use();
}

public enum Skilltype{
    Passive,
    Active
}
