using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warehouseEvent : warehouseEventData
{
    
    [SerializeField] private GameObject bus;
    [SerializeField] private GameObject[] arrayOfModels = new GameObject[7];

    private void Start() 
    {
        arrayOfBoxes = arrayOfModels;
        Setup();
    }

    private int timerSeconds;
    private void Setup()
    {
        timerSeconds = 2;
        InvokeRepeating("timer", 0, 1);
    }

    private void timer()
    {
        timerSeconds--;
        if(timerSeconds == 0)
        {   
            bus.GetComponent<Animation>().PlayQueued("busArrive");
            CancelInvoke("timer");
        }
    }

 
}