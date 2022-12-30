using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuelInteraction : electricityEventData, IInteractable
{
    [SerializeField] private GameObject handPlace;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject fuelObject;
    private Vector3 fuelStartPos;
    private Quaternion fuelStartRotation;

    void Start()
    {//reseting main values
        isFuelPickedUp = false;
        fuelStartPos = fuelObject.transform.position;
        fuelStartRotation = fuelObject.transform.rotation;
    }

    private void fuelPos()
    {//fuel is folowing the player
        if (isFuelPickedUp)
        {
            fuelObject.transform.position = handPlace.transform.position;
            fuelObject.transform.rotation = handPlace.transform.rotation;
        }
        else
        {
            fuelObject.transform.position = fuelStartPos;
            fuelObject.transform.rotation = fuelStartRotation;
            CancelInvoke();
        }
    }

    public string GetDescription()
    {
        if (!isFuelPickedUp) return "Press [E] to <color=green>pick up</color> the fuel";
        return "Press [E] to <color=red>put back</color> the fuel";
    }

    public void Interact()
    {
        if (!isFuelPickedUp && !playerInteraction.isSomethingInHands && !player.GetComponent<Animation>().isPlaying)
        {
            playerInteraction.isSomethingInHands = true;
            isFuelPickedUp = true;
            InvokeRepeating("fuelPos", 0, 0.001f);
            player.GetComponent<Animation>().PlayQueued("pickFuel");
        }
        else if (isFuelPickedUp && !player.GetComponent<Animation>().isPlaying)
        {
            isFuelPickedUp = false;
            player.GetComponent<Animation>().PlayQueued("throwFuel");
            playerInteraction.isSomethingInHands = false;
        }
    }
    public bool isEnableUI()
    {
        return true;
    }

    public bool isAlwaysEnableOutline(){
        return false;
    }
}
