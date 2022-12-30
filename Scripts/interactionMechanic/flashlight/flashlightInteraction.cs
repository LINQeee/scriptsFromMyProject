using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightInteraction : MonoBehaviour
{
    private bool isFlashlightTurnedOn;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(!isFlashlightTurnedOn && !GetComponent<Animation>().isPlaying && !playerInteraction.isSomethingInHands)
            {
                isFlashlightTurnedOn = true;
                playerInteraction.isSomethingInHands = true;
                GetComponent<Animation>().Play("pickUpFlashlight");
            }
            else if(isFlashlightTurnedOn && !GetComponent<Animation>().isPlaying)
            {
                isFlashlightTurnedOn = false;
                playerInteraction.isSomethingInHands = false;
                GetComponent<Animation>().Play("putDownFlashlight");
            }
        }
    }
}
