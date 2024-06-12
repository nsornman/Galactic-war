using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public abstract class CardItem : ScriptableObject
{
    public string cardname;
    [TextArea(5,20)]
    public string Description;
    public Image Cardimage;
    public itemtype Type = new itemtype();
}

public enum itemtype{
    Contructionitem,
    Skillitem
}
