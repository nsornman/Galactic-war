using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public enum itemtype{
    Contructionitem,
    Skillitem
}

public abstract class CardItem : ScriptableObject
{
    public string CardName;
    public Sprite CardSprite;
    [TextArea(5,20)]
    public string Description;
    public itemtype Type = new itemtype();
}


