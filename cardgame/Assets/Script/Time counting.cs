using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    public Gamemanager gameManager;

    void Awake(){
        gameManager = FindObjectOfType<Gamemanager>();
    }
    void Update()
    {
        switch(gameManager.currentPhase){
            case Gamemanager.GamePhase.Building:
                if(gameManager.Timerunner <= gameManager.buildingTime){
                    timerText.text = (gameManager.buildingTime - gameManager.Timerunner).ToString();
                }else{
                    timerText.text = "0";
                }
                break;
            case Gamemanager.GamePhase.Attacking:
                if(gameManager.Timerunner <= gameManager.attackTime){
                    timerText.text = (gameManager.attackTime - gameManager.Timerunner).ToString();
                }else{
                    timerText.text = "0";
                }
                break;
        }
    }
}
