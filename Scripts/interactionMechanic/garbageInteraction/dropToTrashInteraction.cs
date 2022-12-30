using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropToTrashInteraction : garbageEventData,IInteractable
{
    [SerializeField] private AudioClip dropToGarbageSound;
    public static bool isCollectedAlltrash;

    private void Start()
    {
        isCollectedAlltrash = false;
    }
    public string GetDescription()
    {
        if (isCollectedAlltrash) return "<color=green>you have collected all the trash</color>";
        if (countTrashInBag != 0) return "throw trash in the garbage";
        return $"you have already collected <color=green>{garbageEvent.alreadyCollected}</color> / {garbageEvent.totalTrash} trash";
    }
    public void Interact()
    {
       if(!isCollectedAlltrash && isGarbagePickedUp && countTrashInBag != 0)
        {//if minigame didn't finisged play animation and add 1 point
            player.GetComponent<Animation>().PlayQueued("garbageDrop");
            player.GetComponent<AudioSource>().PlayOneShot(dropToGarbageSound);
            Invoke("setInvisible", 1);
            playerInteraction.isSomethingInHands = false;
            isGarbagePickedUp = false;
            garbageEvent.takeOneTrash();
            countTrashInBag = 0;
        }
    }
    public bool isEnableUI()
    {
        return true;
    }
    private void setInvisible()
    {
        garbage.transform.localScale = new Vector3(0.12f, 0.14f, 0.14f);
        garbage.SetActive(false);
    }

    public bool isAlwaysEnableOutline(){
        return false;
    }
}
