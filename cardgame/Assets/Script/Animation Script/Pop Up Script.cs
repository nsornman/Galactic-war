using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpScript : MonoBehaviour
{
    public TMP_Text popupText;
    //public TMP_Text queueText; // Text element to display the queue contents

    private GameObject window;
    private Animator popupAnimator;

    private Queue<string> popupQueue;
    private Coroutine queueChecker;
    public bool Shown;

    private void Start() {
        window = transform.GetChild(0).gameObject;
        popupAnimator = window.GetComponent<Animator>();
        window.SetActive(false);
        popupQueue = new Queue<string>();
    }

    public void AddToQueue(string text) {
        popupQueue.Enqueue(text);
        UpdateQueueText();
        if (queueChecker == null)
            queueChecker = StartCoroutine(CheckQueue());
    }

    private void ShowPopup(string text) {
        window.SetActive(true);
        popupText.text = text;
        popupAnimator.Play("Pop In");
        Shown = true;
    }

    private IEnumerator CheckQueue() {
        while (popupQueue.Count > 0) {
            // Show the next popup message
            string nextMessage = popupQueue.Dequeue();
            ShowPopup(nextMessage);
            UpdateQueueText();

            // Wait for the popup animation to start and complete
            yield return new WaitForSeconds(popupAnimator.GetCurrentAnimatorStateInfo(0).length);
            // Wait until the popup animation is complete and the popup window is idle
            while (popupAnimator.GetCurrentAnimatorStateInfo(0).IsName("Pop In") && !popupAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Idle")) {
                yield return null;
            }
        }

        // Hide the popup window when the queue is empty
        window.SetActive(false);
        queueChecker = null;
    }

    private void UpdateQueueText() {
        // if (queueText != null) {
        //     queueText.text = "Queue: ";
        //     foreach (string item in popupQueue) {
        //         queueText.text += item + " ";
        //     }
        // }
    }
}