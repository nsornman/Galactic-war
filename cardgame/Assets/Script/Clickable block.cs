using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Clickableblock : MonoBehaviour
{
    public bool hasDestroyed = false;
    public GameObject BuildableBlock;
    public GameObject AttackableBlock;
    [Header("For Debug")]
    public GameObject ModelHolder;
    public DataTransform carddata;
    public ConstructionCard constructionCard;
    private GameObject instantiated;
    [HideInInspector]public ConstructionCard blockdata;
    public bool havemodel = false;
    
    private void Awake()
    {
        carddata = FindObjectOfType<DataTransform>();
    }
    public void Update(){
        CheckDestroyed();
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
        if(!hasDestroyed){
            if(constructionCard != null){
                Vector3 modelPosition = ModelHolder.transform.position;
                blockdata = constructionCard;
                if(!havemodel){
                    blockdata.Use(modelPosition);
                    instantiated = blockdata.Instantiatemodel;
                    carddata.placed = true;
                    havemodel = true;
                }
            }
        }
    }
    public void Destroyed(){
        hasDestroyed = true;
    }
    public void NewBlock(){
        hasDestroyed = false;
    }
    public void CheckDestroyed(){
        if(hasDestroyed){
            BuildableBlock.SetActive(false);
            this.blockdata = null;
            if(havemodel){
                Destroy(instantiated);
                havemodel = false;
            }
        }else{
            BuildableBlock.SetActive(true);
        }
    }
}
