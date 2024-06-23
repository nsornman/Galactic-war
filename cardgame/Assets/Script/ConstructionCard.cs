using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

[CreateAssetMenu (menuName ="Card/Contruction Card", fileName ="new Contruction card")]
public class ConstructionCard : CardItem
{
    public int Woodcost;
    public int Metalcost;
    public int Concretecost;
    public int Stonecost;
    public GameObject Model;
    [HideInInspector] public GameObject Instantiatemodel;
    Player player;

    public void Awake(){
        Type = itemtype.Contructionitem;
    }
    public GameObject Use(Vector3 cardholderPosition){
        Instantiatemodel = Instantiate(Model, cardholderPosition, Quaternion.identity);
        return Instantiatemodel;
    }
}
