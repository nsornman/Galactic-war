using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinistryOfDefence : Construction
{
    public override void OnUse()
    {
        switch (level)
        {
            case 1:
                break;
            case 2:
                GetfreeAttack(ShufflewithPercentage(50));
                break;
        }       
    }

    public void GetfreeAttack(bool Boolean){
        if(true){
            player.attackcount += 1;
            Debug.Log("get 1 free attack");
        }
    }
}
