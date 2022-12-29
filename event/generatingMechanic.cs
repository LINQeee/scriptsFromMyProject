using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatingMechanic : MonoBehaviour
{
    public static List<GameObject> GetChildren(GameObject parent)
    {//getting child of object for garbage and broom events
        var list = new List<GameObject>();
        foreach (Transform transform in parent.transform)
        {
            list.Add(transform.gameObject);
        }
        return list;
    }
    public static int generate_GetCount(List<GameObject> listOfObjects)
    {//generating random objects for garbage and broom events
        int countOfObjects = 0;
        foreach (var gameObject in listOfObjects)
        {
            if (new System.Random().Next(100) % 3 == 0)
            {
                gameObject.SetActive(true);
                countOfObjects++;
            }
        }
        return countOfObjects;
    }
}
