using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Clickableblock : MonoBehaviour
{
    [Header("For Debug")]
    public GameObject ModelHolder;
    public DataTransform carddata;
    public ConstructionCard constructionCard;
    public bool havemodel = false;
    
    private void Awake()
    {
        carddata = FindObjectOfType<DataTransform>();
    }
    public void Update(){
        SetConstruct();
    }
    public void SetConstruct(){
        if(carddata.Construct){
            //Debug.Log("holding construction card");
            constructionCard = carddata.cardusing as ConstructionCard;
        }else{
            constructionCard = null;
        }
    }
    private void OnMouseDown(){
        Vector3 modelPosition = ModelHolder.transform.position;
        if(!havemodel){
            constructionCard.Use(modelPosition);

            carddata.placed = true;
            havemodel = true;
        }
    }
}
