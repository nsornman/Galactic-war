using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : MonoBehaviour
{
    public string MatName;
    public int value;

    public virtual void Pay(int costs){
        value -= costs;
        Debug.Log($"Player is paying with {MatName} for {costs} and have {value} of {MatName} left.");
    } 
}
