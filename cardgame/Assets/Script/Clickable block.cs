using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Clickableblock : MonoBehaviour
{
    public GameObject Block;
    private void OnMouseDown(){
        Block.SetActive(false);
    }
    private void Awake()
    {
        // Assign the current game object to the Block variable
        Block = this.gameObject;
    }
    
}
