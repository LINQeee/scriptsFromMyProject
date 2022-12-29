using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class broomPickDrop : MonoBehaviour, IInteractable
{
    public static bool isBroomPickedUp;
    [SerializeField] private GameObject handPlace;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject broomObject;
    private Vector3 broomStartPos;
    private Quaternion broomStartRotation;

    void Start()
    {//fill in main values
        isBroomPickedUp = false;
        broomStartPos = broomObject.transform.position;
        broomStartRotation = broomObject.transform.rotation;
    }

    private void broomPos()
    {//broom is folowing the player
        if (isBroomPickedUp)
        {
            broomObject.transform.position = handPlace.transform.position;
            broomObject.transform.rotation = handPlace.transform.rotation;
        }
        else
        {
            broomObject.transform.position = broomStartPos;
            broomObject.transform.rotation = broomStartRotation;
            CancelInvoke();
        }
    }

    public string GetDescription()
    {
        if (!isBroomPickedUp) return "Press [E] to <color=green>pick up</color> the broom.";
        return "Press [E] to <color=red>put back</color> the broom.";
    }

    public void Interact()
    {
        if (!isBroomPickedUp && !playerInteraction.isSomethingInHands)
        {
            playerInteraction.isSomethingInHands = true;
            isBroomPickedUp = true;
            InvokeRepeating("broomPos", 0, 0.001f);
            player.GetComponent<Animation>().Play("pickBroom");
        }
        else if (isBroomPickedUp)
        {   
            playerInteraction.isSomethingInHands = false;
            isBroomPickedUp = false;
            player.GetComponent<Animation>().Play("throwBroom");
        }
    }
    public bool isEnableUI()
    {
        return true;
    }
}

