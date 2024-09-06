using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : Construction
{
    [Header("Farm")]
    public int WoodRecieve = 10;
    public int StoneRecieve = 5;
    public int ConcreteRecieve = 3;
    public int MetalRecieve = 5;
    public override void Awake()
    {
        base.Awake();
        preBuild = true;
        if(!fromB)
        popUpScript.AddToQueue("Farm Builded");
    }
    public override void OnUse()
    {
        player.Recieve(WoodRecieve , MetalRecieve , ConcreteRecieve , StoneRecieve);
    }
}
