using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Clickableblock : MonoBehaviour
{
    public GameObject Block;
    public DataTransform carddata;
    private void OnMouseDown(){
        carddata.cardusing.Use();
    }
    private void Awake()
    {
        // Assign the current game object to the Block variable
        Block = this.gameObject;
    }
    public void Update(){
        if(carddata.cardusing.Type == itemtype.Contructionitem){
            Debug.Log("holding construction card");
        }
    }

    
}
