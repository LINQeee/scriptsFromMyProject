using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garbageEvent : garbageEventInfo
{
    public static int alreadyCollected = 0;
    private static List<GameObject> listOfTrash = new List<GameObject>();
    private static bool islistGenerated;
    
    public static void Setup()
    {
        if (!islistGenerated) { listOfTrash = generatingMechanic.GetChildren(GameObject.Find("trashs")); islistGenerated = true; }
        foreach (var gameObject in listOfTrash) { gameObject.SetActive(false); }
        totalTrash = generatingMechanic.generate_GetCount(listOfTrash);
        countTrashInBag = 0;
        isGarbagePickedUp = false;
        isCanDrop = true;
        garbage = GameObject.Find("GarbageInteraction");
        player = GameObject.Find("hero");
    }
    
    public static void takeOneTrash()
    {   
        alreadyCollected += countTrashInBag;
        
        if(alreadyCollected == totalTrash) dropToTrashInteraction.isCollectedAlltrash = true;
    }


}
