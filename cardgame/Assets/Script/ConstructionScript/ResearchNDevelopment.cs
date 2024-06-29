using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchNDevelopment : Construction
{
    [Header("Research and Development")]
    public InventoryManager inventoryManager;


    public override void Awake()
    {
        preBuild = true;
        base.Awake();
        inventoryManager = FindObjectOfType<InventoryManager>();
    }
    public override void OnUse()
    {
        switch (level)
        {
            case 1:
                GetSkillCard(ShufflewithPercentage(50));
                break;
            case 2:
                GetSkillCard(ShufflewithPercentage(100));
                break;
        }
    }

    public void GetSkillCard(bool ShuffleWithPercent){
        if(true){
            inventoryManager.addrandomSkill();
            Debug.Log("Added Skill card");
        }
    }
}
