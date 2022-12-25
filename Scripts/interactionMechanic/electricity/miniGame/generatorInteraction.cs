using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatorInteraction : electricityEventData, IInteractable
{   
    public string GetDescription()
    {
        return isNeedFillFuel ? "refuel the generator" : "you don't need to refuel the generator";
    }
    public bool isEnableUI()
    {
        return true;
    }
    public void Interact()
    {
        if(!sliderGame.isPlaying && !GameObject.Find("fuelMinigame").GetComponent<Animation>().isPlaying && isNeedFillFuel)
        GameObject.Find("fuelMinigame").GetComponent<sliderGame>().startPlaying();
    }
}
