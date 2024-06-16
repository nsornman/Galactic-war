using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="Card/Contruction Card", fileName ="new Contruction card")]
public class ConstructionCard : CardItem
{
    public GameObject model;
    public int Woodcost;
    public int Metalcost;
    public int Concretecost;
    public int Stonecost;
    public void Awake(){
        Type = itemtype.Contructionitem;
    }
    public override void Use(){

    }
}
