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
    [SerializeField] protected Player player;
    [Header("Assign in carditem")]
    public int Levelcap;
    public abstract void OnUse();
    public virtual void Awake()
    {
        Transform parent = transform.parent;
        if(parent != null){
            Transform Grandparent = parent.parent;
            if(Grandparent != null){
                clickableblock = Grandparent.GetComponent<Clickableblock>();
            }
        }
        player = FindObjectOfType<Player>();
        Levelcap = clickableblock.blockdata.Levelcap;
    }
    public void Onleveling(){
        if(!CheckMaxLevel()){
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

    public bool CheckMaxLevel(){
        if(level >= Levelcap){
            return true;
        }else{
            return false;
        }
    }

    public virtual int Shuffle(int Length){
        return Random.Range(0 , Length);
    }

    public virtual bool ShufflewithPercentage(int percent)
    {
        // Clamp the percentage to be between 0 and 100
        percent = Mathf.Clamp(percent, 0, 100);

        // Generate a random number between 0 and 99
        int randomValue = Random.Range(0, 100);

        // Return true if the random value is less than the percentage
        return randomValue < percent;
    }
}
