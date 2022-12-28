using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class houseTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered");
        if(other.CompareTag("customer")) other.GetComponent<soundManager>().isInShop = true;
        else if(other.CompareTag("Player")) other.GetComponentInParent<playerSoundManager>().isInHouse = true;
    }
    private void OnTriggerExit(Collider other)
    {   Debug.Log("a");
        if (other.CompareTag("customer")) other.GetComponent<soundManager>().isInShop = false;
        else if (other.CompareTag("Player")) other.GetComponentInParent<playerSoundManager>().isInHouse = false;
    }
}
