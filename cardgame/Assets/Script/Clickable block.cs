using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Clickableblock : MonoBehaviour
{
    public int HP;
    public int maxHP;
    public int HPDifference;
    public bool hasDestroyed = false;
    public GameObject BuildableBlock;
    public GameObject AttackableBlock;
    [Header("For Debug")]
    public GameObject ModelHolder;
    [HideInInspector] public DataTransform carddata;
    [HideInInspector] public ConstructionCard constructionCard;
    private GameObject instantiated;
    public ConstructionCard blockdata;  //actual real time blockcard data
    public bool havemodel = false;
    
    private void Awake()
    {
        carddata = FindObjectOfType<DataTransform>();
    }
    public void Update(){
        CheckDestroyed();
        SetConstruct();
        if(this.blockdata != null)
        {
            this.blockdata.construction.clickableblock = this.gameObject.GetComponent<Clickableblock>();
        }
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
                    // Set maxHP to blockdata's healthPoint when the model is instantiated
                    maxHP = blockdata.construction.healthPoint;
                    HP = maxHP; // Initialize current HP to max HP
                }
            }
        }
    }
    public void DecreaseHP(int damage){
        if(HP >= 0){
            HP-= damage;
            HPDifference += 1;
        }
        else Destroyed();
    }
    public void IncreaseHP(int increaseAmount){
        this.HP += increaseAmount;
        this.maxHP += increaseAmount;
        if (HP > maxHP) HP = maxHP;
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
