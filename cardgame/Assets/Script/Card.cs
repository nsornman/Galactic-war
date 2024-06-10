using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

[CreateAssetMenu(menuName ="Card" ,fileName ="New card")]
public class Card : ScriptableObject
{
    public string Cardname;
    public string Description;
    public Image CardImage;
    public Type cardtype = new Type();

    public enum Type{
        ConstuctionCard,
        SkillCard
    }
}
