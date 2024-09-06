using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBMove : MonoBehaviour
{
    public PopUpScript popUpScript;
    public GamemanagerA gamemanagerA;
    public Row[] playerBColumn;

    [Header("Card")]
    public ConstructionCard farm;
    public ConstructionCard militaryCamp;
    public ConstructionCard Weaponary;
    public ConstructionCard RnD;
    public ConstructionCard CentralGovernment;
    public ConstructionCard MOD;
    public SkillCard Drawer;

    [Header("forddrawer")]
    public bool incontrol;
    public CardItem card1;
    public CardItem card2;

    protected Gamemanager.GamePhase previousPhase = Gamemanager.GamePhase.None;

    void Update()
    {
        // Check if the phase has changed
        if (gamemanagerA.currentPhase != previousPhase)
        {
            // Update the previousPhase to the current phase
            previousPhase = gamemanagerA.currentPhase;

            // Handle phase-specific actions
            switch (gamemanagerA.currentPhase)
            {
                case Gamemanager.GamePhase.Building:
                    HandleBuildingPhase();
                    break;
                case Gamemanager.GamePhase.Attacking:
                    HandleAttackingPhase();
                    break;
            }
        }
    }

    protected virtual void HandleBuildingPhase()
    {
        switch (gamemanagerA.BuildingPhaseCount)
        {
            case 1:
                playerBColumn[3].row[1].CreateConstruct(militaryCamp);
                playerBColumn[2].row[4].CreateConstruct(farm);
                break;
            case 2:
                // Add logic for case 2 if needed
                card1 = Drawer;
                card2 = farm;
                popUpScript.AddToQueue("Player B attacks missed!");
                playerBColumn[2].row[4].CreateConstruct(militaryCamp);
                playerBColumn[4].row[0].CreateConstruct(farm);
                break;
            case 3:
                card1 = Drawer;
                card2 = militaryCamp;
                AddPopUp("your MC has [<color=green>2/3</color>] health left");
                break;
            case 4: 
                AddPopUp("your MC has [<color=green>1/3</color>] health left");
                playerBColumn[3].row[2].CreateConstruct(Weaponary);
                card1 = farm;
                card2 = militaryCamp;
                break;
            case 5:
                popUpScript.AddToQueue("Player B attacks missed!");
                AddConstruct(2,5,RnD);
                break;
            case 6:
                popUpScript.AddToQueue("Player B attacks missed!");
                AddConstruct(2,4,CentralGovernment);
                break;
            case 7:
                popUpScript.AddToQueue("Player B attacks missed!");
                popUpScript.AddToQueue("Player B Military Camp is <color=red>Broken</color>");
                break;
            case 8:
                AddPopUp("your MC has <color=orange>death</color>");
                AddPopUp("your MC has [<color=green>1/3</color>] health left");
                break;
            case 9:
                //PlayerA wins
                break;

        }
    }

    protected virtual void HandleAttackingPhase()
    {
        switch (gamemanagerA.AttackingPhaseCount)
        {
            case 1:
                break;
            case 2:
                StartCoroutine(Waitfor(20));
                popUpScript.AddToQueue("PlayerB Attack your (<color=red>Military Camp</color>)");
                gamemanagerA.playerABlock[9].DecreaseHP(1);
                break;
            case 3:
                StartCoroutine(Waitfor(25));
                AddPopUp("PlayerB Attack your (<color=red>Military Camp</color>)");
                gamemanagerA.playerABlock[9].DecreaseHP(1);
                break;
            case 7:
                AddPopUp("PlayerB Attack your(<color=red>Military Camp</color>)");
                AddPopUp("PlayerB Attack your(<color=red>Military Camp</color>)");
                gamemanagerA.playerABlock[9].DecreaseHP(1);
                gamemanagerA.playerABlock[1].DecreaseHP(1);
                break;
        }
    }

    IEnumerator Waitfor(int second){
        yield return new WaitForSeconds(second);
    }

    public void AddConstruct(int column, int row, ConstructionCard card){
        playerBColumn[column-1].row[row-1].CreateConstruct(card);
    }
    public void AddPopUp(string text){
        popUpScript.AddToQueue(text);
    }
}
[System.Serializable]
public class Row{
    public Clickableblock[] row;
}
