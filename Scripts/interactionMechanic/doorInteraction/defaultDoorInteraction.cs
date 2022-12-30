using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defaultDoorInteraction : MonoBehaviour, IInteractable
{
    private bool isOpen;
    private 
    void Start()
    {   
        isOpen = false;
    }

    public string GetDescription()
    {
        if (isOpen) return "Press [E] to <color=red>close</color> the door.";
        return "Press [E] to <color=green>open</color> the door.";
    }

    public void Interact()
    {   if(GetComponent<Animation>().isPlaying) return;
        if (isOpen == false)
        {
            GetComponent<Animation>().PlayQueued("openDoor");
            isOpen = true;
        }
        else
        {
            GetComponent<Animation>().PlayQueued("closeDoor");
            isOpen = false;
        }
    }
    public bool isEnableUI()
    {
        return true;
    }

    public bool isAlwaysEnableOutline(){
        return true;
    }
}
