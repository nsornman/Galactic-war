using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float attackcount;
    [HideInInspector] public float freeattackfromcard = 0;
    public int DamageMultiplier = 1;
    public float CostMultiplier = 1;
    public float GainMultiplier = 1;
    public int Wood;
    public int Metal;
    public int Concrete;
    public int Stone;
    public InventoryManager inventoryManager;
    [HideInInspector]public int Hit = 0;
    [HideInInspector] public bool ShowedLog;


    public void Update(){
        if(attackcount <= 0 && !ShowedLog){
            Debug.Log("Hit "+ Hit + " Times");
            ShowedLog = true;
        }
    }
    public void Pay(int Woodcosts, int Metalcosts, int Concretecosts, int Stonecosts){
        Wood -= Mathf.RoundToInt(Woodcosts * CostMultiplier);
        Metal -= Mathf.RoundToInt(Metalcosts * CostMultiplier);
        Concrete -= Mathf.RoundToInt(Concretecosts * CostMultiplier);
        Stone -= Mathf.RoundToInt(Stonecosts * CostMultiplier);
    }

    public void Recieve(int Woodcosts, int Metalcosts, int Concretecosts, int Stonecosts){
        Wood += Mathf.RoundToInt(Woodcosts * GainMultiplier);
        Metal += Mathf.RoundToInt(Metalcosts * GainMultiplier);
        Concrete += Mathf.RoundToInt(Concretecosts * GainMultiplier);
        Stone += Mathf.RoundToInt(Stonecosts * GainMultiplier);
    }

    public void ResetMat(){
        Wood = 0;
        Metal = 0;
        Concrete = 0;
        Stone = 0;
    }
    public void ResetAttackCount(float attackcount){
        this.attackcount = attackcount;
        DamageMultiplier = 1;
        Hit = 0;
        ShowedLog = false;
        CostMultiplier = 1;
    }
    public void SetCard(int ConstructCard, int SkillCard){
        inventoryManager.StartCard(ConstructCard , SkillCard);
        //Debug.Log("HAlO");
    }
}