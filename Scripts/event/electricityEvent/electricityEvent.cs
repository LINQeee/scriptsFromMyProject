using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class electricityEvent : electricityEventData
{
    [SerializeField] private TextMeshProUGUI text;

    public void Setup()
    {
        fuelPoints = 20;
        isNeedFillFuel = false;
        InvokeRepeating("electricityTimer", 0, 1);
    }

    private void electricityTimer()
    {
        fuelPoints -= 1;
        if(fuelPoints <= 0)
        {
            isNeedFillFuel = true;
            if (isLeverUp)
            {
                isLeverUp = false;
                GameObject.Find("switch").GetComponent<Animation>().PlayQueued("leverDown");
            }
        }
    }

    private void Update()
    {
        text.text = fuelPoints.ToString();
    }

}
