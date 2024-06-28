using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Construction : MonoBehaviour
{
    [Header("Need to Assign")]
    public int healthPoint;
    public int increaseHPperLvl = 1;
    public int level;
    [Header("Auto-assign")]
    public bool preAttack;
    public bool preBuild;
    
    public Clickableblock clickableblock;
    protected Player player;
    [Header("Assign in carditem")]
    public int Hpcap;

    public abstract void OnUse();
    public virtual void Awake()
    {
        Hpcap = clickableblock.blockdata.Hpcap;
        player = FindObjectOfType<Player>();
    }
    public void Onleveling(){
        if(healthPoint < Hpcap){
            level += 1;
            healthPoint += increaseHPperLvl;
            if(clickableblock != null){
                clickableblock.IncreaseHP(increaseHPperLvl);
            }else{
                Debug.Log("cannot assign clickableblock");
            }
        }else{
            Debug.Log("Max Level");
        }
        
    }
}
