using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Wood;
    public int Metal;
    public int Concrete;
    public int Stone;
    public void Pay(int Woodcosts,int Metalcosts,int Concretecosts,int Stonecosts){
        Wood -= Woodcosts;
        Metal -= Metalcosts;
        Concrete -= Concretecosts;
        Stone -= Stonecosts;
    }

    public void recieve(int Woodcosts,int Metalcosts,int Concretecosts,int Stonecosts){
        Wood += Woodcosts;
        Metal += Metalcosts;
        Concrete += Concretecosts;
        Stone += Stonecosts;
    }
    public void ResetMat(){
        Wood =  0;
        Metal = 0;
        Concrete = 0;
        Stone = 0;
    }
}
