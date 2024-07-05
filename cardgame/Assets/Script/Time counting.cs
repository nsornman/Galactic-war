using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float countdownTime = 60f;

    void Update()
    {
        if (countdownTime > 0)
        {
            countdownTime -= Time.deltaTime;
            timerText.text = Mathf.Ceil(countdownTime).ToString(); // Display countdown with no decimal places
        }
        else
        {
            timerText.text = "0"; // Display 0 when countdown reaches 0
        }
    }
}
