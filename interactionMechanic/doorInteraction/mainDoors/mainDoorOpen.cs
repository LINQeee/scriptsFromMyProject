using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainDoorOpen : MonoBehaviour, IInteractable
{
    public GameObject doors;
    void Start()
    {
        doors.SetActive(true);
        doorValues.isOpen = false;
    }

    public string GetDescription()
    {
        if (doorValues.isOpen) return "Press [E] to <color=red>close</color> the door.";
        return "Press [E] to <color=green>open</color> the door.";
    }

    public void Interact()
    {   if (doorValues.isOpen == false)
        {
            doors.GetComponent<Animation>().PlayQueued("openDoors");
            doorValues.isOpen = true;
        }
        else
        {
            doors.GetComponent<Animation>().PlayQueued("closeDoors");
            doorValues.isOpen = false;
        }
    }
    public bool isEnableUI()
    {
        return true;
    }
}
