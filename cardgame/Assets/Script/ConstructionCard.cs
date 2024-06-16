using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

[CreateAssetMenu (menuName ="Card/Contruction Card", fileName ="new Contruction card")]
public class ConstructionCard : CardItem
{
    [HideInInspector]public GameObject cardholder;
    public int Woodcost;
    public int Metalcost;
    public int Concretecost;
    public int Stonecost;
    
    public GameObject Model;
    public void Awake(){
        Type = itemtype.Contructionitem;
    }
    public override void Use(){
        Instantiate(Model, cardholder.transform.position, quaternion.identity);
    }
}
