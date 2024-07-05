using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class ResourceDisplay : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI resourceText;
    public GameManager gameManager; // Reference to GameManager script

    void Start()
    {
        gameManager = GameManager.Instance; // Ensure GameManager.Instance is correctly implemented

        if (resourceText == null)
        {
            Debug.LogError("TMP Text component not assigned to ResourceDisplay script!");
        }

    }

    void UpdateResourceText()
    {
        if (gameManager != null && resourceText != null)
        {
            resourceText.text = $"Wood: {gameManager.StarterWood}\n" +
                                $"Metal: {gameManager.StarterMetal}\n" +
                                $"Concrete: {gameManager.StarterConcrete}\n" +
                                $"Stone: {gameManager.StarterStone}\n";
        }
    }

    void Update()
    {
     UpdateResourceText();
    }
}

