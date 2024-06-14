using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public enum itemtype{
    Contructionitem,
    Skillitem
}

public abstract class CardItem : ScriptableObject
{
    public string CardName;
    public Sprite Cardsprite;
    [TextArea(5,20)]
    public string Description;
    public itemtype Type = new itemtype();
}


