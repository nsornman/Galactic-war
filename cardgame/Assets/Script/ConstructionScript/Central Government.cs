using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class CentralGovernment : Construction
{
    private Construction[] constructions;
    private Gamemanager gamemanager;
    public override void OnUse()
    {
        switch (level)
        {
            case 1:
                if(gamemanager.BuildingPhaseCount % 4 == 0){
                    LevelingHadler();
                    
                }
                break;
            case 2:
                if(gamemanager.BuildingPhaseCount % 2 == 0){
                    LevelingHadler();
                }
                break;
        }
    }
    public override void Awake(){
        base.Awake();
        preBuild = true;
        gamemanager = FindObjectOfType<Gamemanager>();
    }
    public void Update(){
        constructions = FindObjectsOfType<Construction>();
    }

    public void LevelingHadler(){
        int token = 1;
        while(token > 0)
        {
            int shuffleindex = Shuffle(constructions.Length);
            if(!constructions[shuffleindex].CheckMaxLevel()){
                constructions[shuffleindex].Onleveling();
                Debug.Log($"Leveling the {constructions[shuffleindex].name}");
                token --;
            }
        }
    }
}
