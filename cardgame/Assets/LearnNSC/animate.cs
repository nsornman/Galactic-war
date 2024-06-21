using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animate : MonoBehaviour
{
    Animator animator;
    int isWalkHash;
    int isRunHash;
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkHash = Animator.StringToHash("isWalk");
        isRunHash = Animator.StringToHash("isRun");
    }

    void Update()
    {
        bool isRun = animator.GetBool(isRunHash);
        bool isWalk = animator.GetBool(isWalkHash);
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");

        if (!isWalk && forwardPressed)
        {
            animator.SetBool(isWalkHash, true);
        }

        if (isWalk && !forwardPressed)
        {
            animator.SetBool(isWalkHash, false);
        }

        if (!isRun && (isWalk && runPressed))
        {
            animator.SetBool(isRunHash, true);
        }

        if (isRun && (!isWalk || !runPressed))
        {
            animator.SetBool(isRunHash, false);
        }

    }
}