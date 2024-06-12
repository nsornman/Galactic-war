using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="Card/Contruction Card", fileName ="new Contruction card")]
public class ConstructionCard : CardItem
{
    public void Awake(){
        Type = itemtype.Contructionitem;
    }
}
