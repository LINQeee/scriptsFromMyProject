using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleaningBroomEvent : MonoBehaviour
{
    public static int countOfDirts { get; set; }
    private static List<GameObject> listOfDirts = new List<GameObject>();
    private static bool islistGenerated;

    public static void Setup()
    {   //generating list of dirts and reseting points
        if(!islistGenerated){ listOfDirts = generatingMechanic.GetChildren(GameObject.Find("dirts")); islistGenerated = true; }
        foreach (var gameObject in listOfDirts) { gameObject.SetActive(false); }
        countOfDirts = generatingMechanic.generate_GetCount(listOfDirts);
        foreach(var gameObject in listOfDirts)
        {
            gameObject.GetComponent<cleaningProgress>().resetPoints();
        }
        
    }
    public static void cleanOneDirt()
    {
        countOfDirts -= 1;
        if (countOfDirts <= 0)
        {
                
        }
    }


}