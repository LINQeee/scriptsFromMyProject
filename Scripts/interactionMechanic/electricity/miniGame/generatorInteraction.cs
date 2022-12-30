using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatorInteraction : electricityEventData, IInteractable
{   
    public string GetDescription()
    {
        if (isNeedFillFuel)
        {
            return isFuelPickedUp ? "refuel the generator" : "you need a fuel to refuel the generator";
        }
        return "you don't need to refuel the generator";
    }
    public bool isEnableUI()
    {
        return !sliderGame.isPlaying;
    }
    public void Interact()
    {
        if(!sliderGame.isPlaying && !GameObject.Find("fuelMinigame").GetComponent<Animation>().isPlaying && isNeedFillFuel && isFuelPickedUp)
        GameObject.Find("fuelMinigame").GetComponent<sliderGame>().startPlaying();
    }

    public bool isAlwaysEnableOutline(){
        return false;
    }
}
