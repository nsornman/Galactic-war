using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public Player[] player;
    public int StarterWood;
    public int StarterMetal;
    public int StarterConcrete;
    public int StarterStone;
    // Start is called before the first frame update
    void Awake()
    {
        player = FindObjectsOfType<Player>();
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
        for(int i = 0;i< player.Length;i++){
            player[i].recieve(StarterWood,StarterMetal,StarterConcrete,StarterStone);
        }
    }

}
