using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class garbagePickDrop : garbageEventInfo
{
    [SerializeField] private GameObject trash;
    private Animation animationGarbage;
    public bool a;

    void Start()
    {
        trash.SetActive(false);
        animationGarbage = GetComponent<Animation>();
    }

    void Update()
    {
        a = isGarbagePickedUp;
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!isGarbagePickedUp && !animationGarbage.isPlaying && !playerInteraction.isSomethingInHands)
            {
                playerInteraction.isSomethingInHands = true;
                animationGarbage.PlayQueued("garbagePick");
                trash.SetActive(true);
                isGarbagePickedUp = true;
            }
            else if(isGarbagePickedUp && !animationGarbage.isPlaying)
            {
                animationGarbage.PlayQueued("garbageDrop");
               Invoke("setInvisible", 1);
                isGarbagePickedUp = false;
            }
        }
    }
    private void setInvisible()
    {
        trash.SetActive(false);
        playerInteraction.isSomethingInHands = false;
    }
}
