using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class casherInteration : customerEventData, IInteractable
{
    
    public string GetDescription()
    {
          if (!electricityEventData.isLeverUp) return "<color=red>you have to turn on the electricity to serve the customer</color>";
        return isSomeoneWaitingForPay == true ? "<color=green>serve</color> the customer"
        : "<color=red>no</color> customers at the moment";
    }
    public void Interact()
    {
        if(isSomeoneWaitingForPay == false || isUIOpen || !electricityEventData.isLeverUp) return;
        isUIOpen = true;

        GameObject.Find("cashUI").GetComponent<casherGame>().startGame();
    }
    public bool isEnableUI()
    {
        return !isUIOpen;
    }

    public bool isAlwaysEnableOutline(){
        return false;
    }
}
