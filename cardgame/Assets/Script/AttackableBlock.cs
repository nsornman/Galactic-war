using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AttackableBlock : MonoBehaviour
{
    public GameObject motherBlock;
    public Clickableblock dataContainer;
    public Color haveModel;
    public Color noModel;
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
        if(dataContainer.blockdata == null){
            NoStructure();
        }else{
            HaveStructure();
        }
        Enemyplayer.attackcount -=1;
    }
    void HaveStructure()
    {
        SetColor(haveModel);

        Clicked = true;
        dataContainer.Destroyed();
    }
    void NoStructure(){
        SetColor(noModel);
        Clicked = true;
        dataContainer.Destroyed();
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
