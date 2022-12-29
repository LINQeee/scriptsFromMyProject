using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warehouseEvent : warehouseEventData
{
    
    [SerializeField] private GameObject bus;
    [SerializeField] private GameObject[] arrayOfModels = new GameObject[7];
    private int timerSeconds;
    private void Start() 
    {
        arrayOfBoxes = arrayOfModels;
        Setup();
    }

    
    private void Setup()
    {
        timerSeconds = 2;
        InvokeRepeating("timer", 0, 1);
        //TODO mechanic of points
    }
//this timer was made for test
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