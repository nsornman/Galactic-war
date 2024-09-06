using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryCamp : Construction
{
    public override void Awake()
    {
        base.Awake();
        preAttack = true;
        if(!fromB)
        popUpScript.AddToQueue("Military Camp Builded");
    }

    public override void OnUse()
    {
        switch (level)
        {
            case 1:
                player.attackcount += 1;
                break;
            case 2:
                player.attackcount += 2;
                break;
            case 3:
                player.attackcount += 3;
                break;
        }
    }
    // public void OnMouseDown()
    // {
    //     Onleveling();
    // }
}
