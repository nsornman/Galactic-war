using System.Collections;
using System.Collections.Generic;
using Org.BouncyCastle.Asn1.Pkcs;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAMove : PlayerBMove
{
    protected override void HandleAttackingPhase()
    {
        switch (gamemanagerA.AttackingPhaseCount)
        {
            case 2:
                AddPopUp("PlayerB Attack your (<color=red>Military Camp</color>)");
                gamemanagerA.playerABlock[16].DecreaseHP(1);
                break;
            case 3:
                AddPopUp("PlayerB Attack your (<color=red>Military Camp</color>)");
                AddPopUp("PlayerB Attack your (<color=red>Military Camp</color>)");
                gamemanagerA.playerABlock[16].DecreaseHP(1);
                gamemanagerA.playerABlock[22].DecreaseHP(1);
                break;
            case 6:
                AddPopUp("PlayerB Attack your (<color=red>Military Camp</color>)");
                gamemanagerA.playerABlock[16].DecreaseHP(1);
                break;
            case 7:
                AddPopUp("PlayerB Attack your (<color=red>Military Camp</color>)");
                gamemanagerA.playerABlock[22].DecreaseHP(1);
                break;
        }
    }
    protected override void HandleBuildingPhase()
    {
        switch (gamemanagerA.BuildingPhaseCount)
        {
            case 1:
                AddConstruct(2,5,militaryCamp);
                AddConstruct(5,1,farm);
                card1 = farm;
                card2 = Drawer;
                break;
            case 2:
                AddConstruct(3,2,MOD);
                break;
            case 3:
                AddPopUp("your MC has [<color=green>2/3</color>] health left");
                card1 = Drawer;
                card2 = Weaponary;
                break;
            case 4:
                AddPopUp("your MC has [<color=green>1/3</color>] health left");
                AddPopUp("your MC has [<color=green>2/3</color>] health left");
                AddConstruct(3,5,farm);
                AddConstruct(1,2,militaryCamp);
                break;
            case 5:
                AddConstruct(1,1,Weaponary);
                break;
            case 6:
                AddConstruct(1,4,RnD);
                break;
            case 7:
                AddPopUp("your MC has <color=orange>death</color>");
                break;
            case 8:
                AddPopUp("Player B Military Camp is <color=red>Broken</color>");
                AddPopUp("your MC has [<color=green>1/3</color>] health left");
                break;
            case 9:
                //Losing code here
                break;
        }
    }
}
