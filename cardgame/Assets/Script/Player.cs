using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float attackcount = 3;
    public float CostMultiplier;
    public float GainMultiplier;
    public int Wood;
    public int Metal;
    public int Concrete;
    public int Stone;

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
    }
}