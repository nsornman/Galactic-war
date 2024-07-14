using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class ResourceDisplay : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI resourceText;
    public Gamemanager gameManager; // Reference to GameManager script
    public Player playerself;

    void Awake()
    {
        gameManager = FindObjectOfType<Gamemanager>();
        Transform parent = transform.parent;
        if(parent != null){
            playerself = GetComponentInParent<Player>();
        }
        if (resourceText == null)
        {
            Debug.LogError("TMP Text component not assigned to ResourceDisplay script!");
        }

    }

    void UpdateResourceText()
    {
        if (gameManager != null && resourceText != null)
        {
            resourceText.text = $"Wood: {playerself.Wood}\n" +
                                $"Metal: {playerself.Metal}\n" +
                                $"Concrete: {playerself.Concrete}\n" +
                                $"Stone: {playerself.Stone}\n";
        }
    }

    void Update()
    {
     UpdateResourceText();
    }
}

