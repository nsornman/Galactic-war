using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponary : Construction
{

    public override void OnUse()
    {
        switch (level)
        {
            case 1:
                IncreaseDMGMultiply(ShufflewithPercentage(30));
                break;
            case 2:
                IncreaseDMGMultiply(ShufflewithPercentage(60));
                break;
            case 3:
                IncreaseDMGMultiply(ShufflewithPercentage(100));
                break;
        }
    }

    public void IncreaseDMGMultiply(bool Boolean){
        if(true){
            player.DamageMultiplier = 2;
        }
    }
}
