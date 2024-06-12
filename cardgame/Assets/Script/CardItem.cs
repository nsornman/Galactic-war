using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardItem : ScriptableObject
{
    public string cardname;
    [TextArea(5,20)]
    public string Description;
    public itemtype Type = new itemtype();
}

public enum itemtype{
    Contructionitem,
    Playableitem
}
