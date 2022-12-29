using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garbageEventData : MonoBehaviour
{
    protected readonly int limitOfTrash = 3;
    protected static int countTrashInBag;
    protected static bool isGarbagePickedUp;
    protected static bool isCanDrop;
    protected static int totalTrash;

    protected static GameObject garbage;
    protected static GameObject player;
}
