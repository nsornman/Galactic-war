using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using Unity.VisualScripting;
using UnityEngine;

public class Clickableblock : MonoBehaviour//NetworkBehaviour
{
    /*[SyncVar]*/ public int HP;
    /*[SyncVar]*/ public int maxHP;
    /*[SyncVar]*/ public bool hasDestroyed = false;
    public GameObject blockrenderer;
    public GameObject BuildableBlock;
    public GameObject pressedSound;
    //public GameObject AttackableBlock;
    [Header("For Debug")]
    public GameObject ModelHolder;
    public DataTransform carddata;
    [HideInInspector] public ConstructionCard constructionCard;
    private GameObject instantiated;
    public ConstructionCard blockdata;  //actual real time blockcard data
    public Player player;
    public bool havemodel = false;
    public bool forceCreate = false;
    private void Awake()
    {
        Transform parent = this.transform.parent;
        if(parent != null){
            Transform Grandparent = parent.parent;
            if(Grandparent != null){
                Transform GrandgrandParent = Grandparent.parent;
                if(GrandgrandParent!= null){
                    player = GrandgrandParent.GetComponent<Player>();
                    carddata = GrandgrandParent.GetComponent<DataTransform>();
                }Debug.Log("GrandgrandParent = null");
            }else{
                Debug.Log("GrandParen = null");
            }
        }else{
            Debug.Log("parent = null");
        }
        blockrenderer = transform.GetChild(0).gameObject;
        pressedSound = Resources.Load<GameObject>("press sound");
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
        if (!carddata.Construct)
        {
            constructionCard = null;
        }
        else
        {
            //Debug.Log("holding construction card");
            constructionCard = carddata.cardusing as ConstructionCard;
        }
    }
    private void OnMouseDown(){
        if(!hasDestroyed){
            if(constructionCard != null){
                Vector3 modelPosition = ModelHolder.transform.position;
                if(CheckMat(player , constructionCard)){
                        blockdata = constructionCard;
                    if(!havemodel){
                        blockdata.Use(modelPosition , this.BuildableBlock.gameObject.transform);
                        player.Pay(blockdata.Woodcost,blockdata.Metalcost,blockdata.Concretecost,blockdata.Stonecost);
                        Instantiate(pressedSound , this.transform);
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
    public void CreateConstruct(ConstructionCard card){
        Vector3 modelPosition = ModelHolder.transform.position;
        blockdata = card;
        if(!havemodel){
            forceCreate = true;
            card.Use(modelPosition , this.BuildableBlock.gameObject.transform);
            instantiated = blockdata.Instantiatemodel;
            havemodel = true;
            // Set maxHP to blockdata's healthPoint when the model is instantiated
            maxHP = blockdata.Model.GetComponent<Construction>().healthPoint;
            HP = maxHP; // Initialize current HP to max HP
            Debug.Log("Create "+ card.name+ " on "+ this.name);
        }else{
            Debug.Log("Create but already have model");
        }
    }
    public void DecreaseHP(int damage){
        if(HP >= 0){
            HP-= damage;
            if(maxHP- HP==1){
                SetColor(Color.yellow);
            }else if(maxHP-HP >= 1){
                SetColor(Color.red);
            }
            Debug.Log("Decreased");
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
        if((this.hasDestroyed || this.HP <= 0) && this.maxHP != 0){
            BuildableBlock.gameObject.SetActive(false);
            this.blockdata = null;
            if(havemodel){
                Destroy(instantiated);
                havemodel = false;
            }
        }else{
            BuildableBlock.gameObject.SetActive(true);
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
    void SetColor(Color color)
{
    Renderer renderer = blockrenderer.GetComponentInChildren<Renderer>();
    if (renderer != null)
    {
        // Create a new MaterialPropertyBlock
        MaterialPropertyBlock block = new MaterialPropertyBlock();
        
        // Set the color property
        block.SetColor("_Color", color);

        // Apply the MaterialPropertyBlock to the renderer
        renderer.SetPropertyBlock(block);

        Debug.Log($"Color set to {color}");
    }
    else
    {
        Debug.LogWarning("Renderer component not found!");
    }
}
}
