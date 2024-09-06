using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class AttackableBlock : MonoBehaviour
{
    public int DamageDealt = 1;
    //public GameObject motherBlock;
    /*[SyncVar]*/ public Clickableblock dataContainer;
    public Color Break;
    public Color Marked;
    /*[SyncVar]*/ public bool Clicked;
    [SerializeField]private Player enemyPlayer;

    public void Awake()
    {
        // for(int i = 0;i< allPlayer.Length ; i++){
        //     if(!allPlayer[i].isOwned){return;}
        //     enemyPlayer = allPlayer[i];
        // }
        dataContainer = GetComponentInParent<Clickableblock>();
    }
    void OnMouseDown(){ //ClickTime logic goes here
        if(!Clicked && enemyPlayer.attackcount != 0){
            CheckType();
        }
    }

    public void CheckType(){ // should be some Active skill code somewhere in here
        if(dataContainer.blockdata != null){
            AttackHit();

        }else{
            AttackNotHit();
        }
        
    }
    void AttackNotHit(){
        SetColor(Marked);
        Clicked = true;
        enemyPlayer.attackcount -= 1;
        Debug.Log("Not Hit Anything");
    }
    void AttackHit()
    {
        dataContainer.DecreaseHP(DamageDealt * enemyPlayer.DamageMultiplier);
        if(dataContainer.HP <= 0){
            SetColor(Break);
            Debug.Log("Hit but NotDestroyed");
        }else{
            SetColor(Marked);
            Debug.Log("Hit and Destroyed");
        }
        Clicked = true;
        enemyPlayer.attackcount -= 1;
        enemyPlayer.Hit += 1;
    }
    void SetColor(Color color){
        // Create a new MaterialPropertyBlock
        MaterialPropertyBlock block = new MaterialPropertyBlock();

        // Set the color property
        block.SetColor("_Color", color);

        // Apply the MaterialPropertyBlock to the renderer
        Renderer renderer = this.gameObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.SetPropertyBlock(block);
        }
    }
}
