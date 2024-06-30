using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu (menuName ="Card/Contruction Card", fileName ="new Contruction card")]
public class ConstructionCard : CardItem
{
    [Header("Assign Variable")]
    public int Levelcap;
    public int Woodcost;
    public int Metalcost;
    public int Concretecost;
    public int Stonecost;
    [Header("Assign Prefab")]
    public GameObject Model;
    //public Construction construction;
    
    [HideInInspector] public GameObject Instantiatemodel;

    public void Awake(){
        Type = itemtype.Contructionitem;
    }
    public GameObject Use(Vector3 cardholderPosition , Transform transformParent){
        if(Model != null){
            Renderer ModelRenderer = Model.GetComponent<Renderer>();

            if(ModelRenderer != null){
                float modelHeight = ModelRenderer.bounds.size.y;

                Vector3 AdjustedPosition = cardholderPosition + new Vector3(0, modelHeight /2, 0);
                Instantiatemodel = Instantiate(Model, AdjustedPosition , Quaternion.identity , transformParent);
            }
            else{
                Instantiatemodel = Instantiate(Model, cardholderPosition, Quaternion.identity , transformParent);
            }
        }
        
        return Instantiatemodel;
    }
}
