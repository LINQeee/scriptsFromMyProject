using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class houseTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered");
        if(other.CompareTag("customer")) other.GetComponent<soundManager>().isInShop = true;
        else if(other.CompareTag("Player")) other.GetComponent<playerSoundManager>().isInHouse = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("customer")) other.GetComponent<soundManager>().isInShop = false;
        else if (other.CompareTag("Player")) other.GetComponent<playerSoundManager>().isInHouse = false;
    }
}
