using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerCamera : NetworkBehaviour
{
    [Header("Camera")]
    [SerializeField]private Camera playerCamera;

    public override void OnStartAuthority()
    {
        Debug.Log("OnStartAuthority called on " + gameObject.name);
        if (playerCamera != null)
        {
            playerCamera.gameObject.SetActive(true);
            Debug.Log("Player camera enabled");
        }
        else
        {
            Debug.Log("No Camera component found in children.");
        }
    }
}