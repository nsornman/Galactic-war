using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveSkill : MonoBehaviour
{
    public Buff  buff = new Buff();
    [Header("Auto-Assign")]
    public Player player;
    public InventoryManager IM;
    public PlayerBMove thirdParties;
    public void Awake()
    {
        thirdParties = FindObjectOfType<PlayerBMove>();
        player = GetComponentInParent<Player>();
        IM = player.inventoryManager;
        switch (buff)
        {
            case Buff.IncreaseResourceGain:
                player.GainMultiplier *= 2;
                break;
            case Buff.DecreaseResourceSpend:
                player.CostMultiplier *= 0.5f;
                break;
            case Buff.Add2MoreDrawer:
                if(!thirdParties.incontrol){
                    for(int i=0;i<2;i++){
                        IM.AddfromRandomArr(ShufflewithPercentage(50));
                    }
                }else{
                    IM.AddNonSpecificCard(thirdParties.card1);
                    IM.AddNonSpecificCard(thirdParties.card2);
                }
                break;
        }
    }

    public bool ShufflewithPercentage(int percent)
    {
        // Clamp the percentage to be between 0 and 100
        percent = Mathf.Clamp(percent, 0, 100);

        // Generate a random number between 0 and 99
        int randomValue = Random.Range(0, 100);

        // Return true if the random value is less than the percentage
        return randomValue < percent;
    }
}
public enum Buff{
    IncreaseResourceGain,
    DecreaseResourceSpend,
    Add2MoreDrawer
}
