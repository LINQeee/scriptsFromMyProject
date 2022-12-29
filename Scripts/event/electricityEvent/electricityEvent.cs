using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class electricityEvent : electricityEventData
{
    public void Setup()
    {
        fuelPoints = 180;
        isNeedFillFuel = false;
        InvokeRepeating("electricityTimer", 0, 1);
    }

    private void electricityTimer()
    {
     if(fuelPoints>0)   fuelPoints -= 1;
      else
        {
            isNeedFillFuel = true;
            if (isLeverUp)
            {
                isLeverUp = false;
                GameObject.Find("switch").GetComponent<Animation>().PlayQueued("leverDown");
            }
        }
    }

}
