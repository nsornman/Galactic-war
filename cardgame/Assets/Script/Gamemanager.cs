using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public material[] mat;
    public int StarterWood;
    public int StarterMetal;
    public int StarterConcrete;
    public int StarterStone;
    // Start is called before the first frame update
    void Awake()
    {
        mat = FindObjectsOfType<material>();
    }
    void Start()
    { 
        SetCurrency();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetCurrency(){
        for(int i = 0;i< mat.Length;i++){
            mat[i].recieve(StarterWood,StarterMetal,StarterConcrete,StarterStone);
        }
    }

}
