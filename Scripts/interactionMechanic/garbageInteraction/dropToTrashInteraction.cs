using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropToTrashInteraction : garbageEventInfo,IInteractable
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
        {
            player.GetComponent<Animation>().PlayQueued("garbageDrop");
            player.GetComponent<AudioSource>().PlayOneShot(dropToGarbageSound);
            Invoke("setInvisible", 1);
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
}
