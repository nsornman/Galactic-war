using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableBlock : MonoBehaviour
{
    public int DamageDealt = 1;
    public GameObject motherBlock;
    public Clickableblock dataContainer;
    public Color Break;
    public Color Marked;
    public bool Clicked;
    private Player Enemyplayer;

    public void Awake()
    {
        Enemyplayer = FindObjectOfType<Player>();
    }
    void OnMouseDown(){ //ClickTime logic goes here
        if(!Clicked && Enemyplayer.attackcount != 0){
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
        Enemyplayer.attackcount -= 1;
        Debug.Log("Not Hit Anything");
    }
    void AttackHit()
    {
        dataContainer.DecreaseHP(DamageDealt * Enemyplayer.DamageMultiplier);
        if(dataContainer.HP <= 0){
            SetColor(Break);
            Debug.Log("Hit but NotDestroyed");
        }else{
            SetColor(Marked);
            Debug.Log("Hit and Destroyed");
        }
        Clicked = true;
        Enemyplayer.attackcount -= 1;
        Enemyplayer.Hit += 1;
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
