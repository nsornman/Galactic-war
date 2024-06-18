using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Clickableblock : MonoBehaviour
{
    [Header("For Debug")]
    public GameObject Block;
    public DataTransform carddata;
    public ConstructionCard constructionCard;
    
    private void Awake()
    {
        carddata = FindObjectOfType<DataTransform>();
        Block = this.gameObject;
    }
    public void Update(){
        SetConstruct();
    }
    public void SetConstruct(){
        if(carddata.Construct){
            //Debug.Log("holding construction card");
            constructionCard = carddata.cardusing as ConstructionCard;
        }
    }
    private void OnMouseDown(){
        constructionCard.cardholder = Block;
        constructionCard.Use();
    }
}
