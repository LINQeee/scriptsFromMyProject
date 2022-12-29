using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationManager : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void horizontalCheck()
    {
        switch (Input.GetAxis("Horizontal"))
        {
            case < 0:
                animator.SetInteger("leftRightTrigger", -1);
                break;
            case 0:
                animator.SetInteger("leftRightTrigger", 0);
                break;
            case > 0:
                animator.SetInteger("leftRightTrigger", 1);
                break;
        }
    }
    private void verticalCheck()
    {
        switch (Input.GetAxis("Vertical"))
        {
            case < 0:
                animator.SetInteger("forwardBackTrigger", -1);
                break;
            case 0:
                animator.SetInteger("forwardBackTrigger", 0);
                break;
            case > 0:
                animator.SetInteger("forwardBackTrigger", 1);
                break;
        }
    }
    void Update()
    {
        if (playerMovement.isMovementBlocked)
        {
            animator.SetInteger("forwardBackTrigger", 0); animator.SetInteger("leftRightTrigger", 0); return;
        }
        //tracking a and d buttons input
        horizontalCheck();
        //tracking w and s buttons input
        verticalCheck();
    }
}
