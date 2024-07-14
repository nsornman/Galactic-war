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
        int BuildTimer = Mathf.Max(0, Mathf.CeilToInt(gameManager.buildingTime - gameManager.Timerunner));
        int AttackTimer = Mathf.Max(0, Mathf.CeilToInt(gameManager.attackTime - gameManager.Timerunner));
        switch(gameManager.currentPhase){
            case Gamemanager.GamePhase.Building:
                if(gameManager.Timerunner <= gameManager.buildingTime){
                    timerText.text = BuildTimer.ToString();
                }else{
                    timerText.text = "0";
                }
                break;
            case Gamemanager.GamePhase.Attacking:
                if(gameManager.Timerunner <= gameManager.attackTime){
                    timerText.text = AttackTimer.ToString();
                }else{
                    timerText.text = "0";
                }
                break;
        }
    }
}
