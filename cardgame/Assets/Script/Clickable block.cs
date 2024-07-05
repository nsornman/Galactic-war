using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Clickableblock : MonoBehaviour
{
    public int HP;
    public int maxHP;
    public bool hasDestroyed = false;
    public GameObject BuildableBlock;
    public GameObject AttackableBlock;
    [Header("For Debug")]
    public GameObject ModelHolder;
    [HideInInspector] public DataTransform carddata;
    [HideInInspector] public ConstructionCard constructionCard;
    private GameObject instantiated;
    public ConstructionCard blockdata;  //actual real time blockcard data
    public Player player;
    public bool havemodel = false;
    
    private void Awake()
    {
        Transform parent = transform.parent;
        if(parent != null){
            Transform Grandparent = parent.parent;
            if(Grandparent != null){
                carddata = Grandparent.GetComponent<DataTransform>();
                Transform GrandgrandParent = Grandparent.parent;
                if(GrandgrandParent!= null){
                    player = GrandgrandParent.GetComponent<Player>();
                }
            }

        }
    }
    public void Update(){
        CheckDestroyed();
        SetConstruct();
        // if(this.blockdata != null)
        // {
        //     this.blockdata.Model.GetComponent<Construction>().clickableblock = this.GetComponent<Clickableblock>(); 
        // }
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
                if(CheckMat(player , constructionCard)){
                        blockdata = constructionCard;
                    if(!havemodel){
                        blockdata.Use(modelPosition , this.BuildableBlock.transform);
                        player.Pay(blockdata.Woodcost,blockdata.Metalcost,blockdata.Concretecost,blockdata.Stonecost);
                        instantiated = blockdata.Instantiatemodel;
                        carddata.placed = true;
                        havemodel = true;
                        // Set maxHP to blockdata's healthPoint when the model is instantiated
                        maxHP = blockdata.Model.GetComponent<Construction>().healthPoint;
                        HP = maxHP; // Initialize current HP to max HP
                    }
                }else{
                    Debug.Log("Material Not Enough!");
                }
            }
        }
    }
    public void DecreaseHP(int damage){
        if(HP >= 0){
            HP-= damage;
        }
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
        if((hasDestroyed || HP <= 0) && maxHP != 0){
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
    public bool CheckMat(Player player, ConstructionCard constructionCard){
        int MetalLeft = player.Metal - Mathf.RoundToInt(constructionCard.Metalcost * player.CostMultiplier);
        int ConcreteLeft = player.Concrete - Mathf.RoundToInt(constructionCard.Concretecost * player.CostMultiplier);
        int StoneLeft = player.Stone - Mathf.RoundToInt(constructionCard.Stonecost * player.CostMultiplier);
        int WoodLeft = player.Wood - Mathf.RoundToInt(constructionCard.Woodcost * player.CostMultiplier);
        if(WoodLeft >= 0 && ConcreteLeft>=0 && StoneLeft >= 0 && MetalLeft >= 0) return true;
        return false;
    }
}
