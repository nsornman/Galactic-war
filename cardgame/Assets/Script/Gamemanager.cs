using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public Player[] player;
    public Clickableblock[] clickableblocks;
    public int StarterWood;
    public int StarterMetal;
    public int StarterConcrete;
    public int StarterStone;
    // Start is called before the first frame update
    void Awake()
    {
        clickableblocks = FindObjectsOfType<Clickableblock>();
        player = FindObjectsOfType<Player>();
    }
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetMats(){
        for(int i = 0;i< player.Length;i++){
            player[i].ResetMat();
            player[i].recieve(StarterWood,StarterMetal,StarterConcrete,StarterStone);
        }
    }
    public void SetNewLives(){
        SetBlock();
        SetMats();
    }
    public void SetBlock(){
        for(int i = 0;i< clickableblocks.Length ; i++){
            clickableblocks[i].Destroyed();
            clickableblocks[i].NewBlock();
        }
    }

}
