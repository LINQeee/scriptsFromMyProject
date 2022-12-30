using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class busInteraction : warehouseEventData, IInteractable
{
    [SerializeField] private GameObject handPlace;
    [SerializeField] private GameObject player;
    private Vector3 startPos;
    private Quaternion startRot;
    public string GetDescription()
    {
        return isBoxInHand? "you <color=red>can't</color> carry more than one box":"<color=green>take</color> one box";
    }

    public void Interact()
    {
        if(!isBoxInHand)
        {
            isBoxInHand = true;
            playerInteraction.isSomethingInHands = true;
            currentBox = arrayOfBoxes[new System.Random().Next(7)];
            startPos = currentBox.transform.position;
            startRot = currentBox.transform.rotation;
            InvokeRepeating("boxPos", 0, 0.001f);
            player.GetComponent<Animation>().PlayQueued("pickUpBox");
        }
    }

    public bool isEnableUI()
    {
        return true;
    }

       private void boxPos()
    {//box is folowing the player
        if (isBoxInHand)
        {
            currentBox.transform.position = handPlace.transform.position;
            currentBox.transform.rotation = handPlace.transform.rotation;
        }
        else
        {
            currentBox.transform.position = startPos;
            currentBox.transform.rotation = startRot;
            CancelInvoke();
        }
    }

    public bool isAlwaysEnableOutline(){
        return true;
    }
}
