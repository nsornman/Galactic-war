using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class material : MonoBehaviour
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
}
