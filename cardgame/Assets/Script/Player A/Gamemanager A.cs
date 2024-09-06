using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamemanagerA : Gamemanager
{
    [Header("for A")]
    public Player playerA;
    public Camera playerACam;
    public Clickableblock[] playerABlock;
    public GameObject BuildPos;
    public GameObject AttackPos;

    public void Awake(){
        player = FindObjectsOfType<Player>();
        popUpScript = FindObjectOfType<PopUpScript>();
    }
    public override void FixedUpdate()
    {
        clickableblocks = FindObjectsOfType<Clickableblock>();
        construction = FindObjectsOfType<Construction>();
        passiveSkill = FindObjectsOfType<PassiveSkill>();
    }
    protected override void Start()
    {
        base.Start();
    }
    public override void SetUpCard()
    {
        if(playerA.inventoryManager != null){
            playerA.PlayerACard();
        }
    }

    public override bool StillAlive()
    {
        for (int i = 0; i < playerABlock.Length; i++)
        {
            if (playerABlock[i].gameObject.activeInHierarchy)
            {
                return true;
            }
        }
        return false;
    }
    public override void WarptoAttack()
    {
        Warpto(AttackPos);
    }
    public override void WarptoBuild()
    {
        Warpto(BuildPos);
    }
    public void Warpto(GameObject position){
        playerACam.transform.position = position.transform.position;
        playerACam.transform.rotation = position.transform.rotation;
        //Debug.Log("Warpto"+ position.name);
    }
    private protected override void SwapAttackPositions()
    {
        //Nothing should be here
    }
    public override bool Waitfor2ndPlayer()
    {
        return true;
    }
}
