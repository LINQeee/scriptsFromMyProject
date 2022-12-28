using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverInteraction : electricityEventData, IInteractable
{
    [SerializeField] private List<Light> lights = new List<Light>();
    [SerializeField] private Material lightMaterial;
    [SerializeField] private Material generatorLigth;
    private void Start()
    {
        setLightsOn();
    }
    public string GetDescription()
    {   if (isNeedFillFuel) return "you have to refuel the generator at first";
        return !isLeverUp ? "raise the lever" : "lower the lever";
    }

    public void Interact()
    {
        if (isLeverUp && !GetComponent<Animation>().isPlaying && !isNeedFillFuel) { GetComponent<Animation>().PlayQueued("leverDown"); isLeverUp = false; }
        else if (!isLeverUp && !GetComponent<Animation>().isPlaying && !isNeedFillFuel) { GetComponent<Animation>().PlayQueued("leverUp"); isLeverUp = true; }
    }
    public bool isEnableUI()
    {
        return true;
    }
    private void setLightsOn()
    {
        foreach (Light light in lights)
        {
            light.enabled = true;
        }
        lightMaterial.SetColor("_EmissiveColor", new Color(15, 15, 15, 1));
        generatorLigth.SetColor("_EmissiveColor", new Color(0, 1024, 0, 1));

    }
    private void setLightsOff()
    {
        foreach (Light light in lights)
        {
            light.enabled = false;
        }
        lightMaterial.SetColor("_EmissiveColor", new Color(0, 0, 0, 1));
        generatorLigth.SetColor("_EmissiveColor", new Color(1024, 0, 0, 1));

    }
}
