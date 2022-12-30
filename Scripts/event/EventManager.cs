using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{


    void Start()
    {
        cleaningBroomEvent.Setup();
        garbageEvent.Setup();
        customerEvent.Setup();
        GetComponent<electricityEvent>().Setup();
        //TODO mechanic tracking of minigames progress
    }

}
