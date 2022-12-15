using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class trashPickInteraction : garbageEventInfo, IInteractable
{
    [SerializeField] private AudioClip pickUpSound;
    void Start()
    {
        
    }

    public string GetDescription()
    {
        if (countTrashInBag == limitOfTrash) return "<color=red>your garbage bag is full, throw it in the garbage</color>";
        return "pick up trash";
    }
    public void Interact()
    {
        if (isGarbagePickedUp && countTrashInBag < limitOfTrash)
        {
            countTrashInBag++;
            gameObject.SetActive(false);
            player.GetComponent<AudioSource>().PlayOneShot(pickUpSound);
            garbage.transform.localScale *= 1.05f;
        }
    }
    public bool isEnableUI()
    {
        if (isGarbagePickedUp)
        {
            return true;
        }
        return false;
    }
}