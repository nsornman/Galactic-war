using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerUI : NetworkBehaviour
{
    [SerializeField] private GameObject playerUI;
    public override void OnStartAuthority()
    {
        playerUI.SetActive(true);
        enabled = true;
    }
}
