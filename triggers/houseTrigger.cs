using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class houseTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {//tracking is customer and player in house
        if(other.CompareTag("customer")) other.GetComponent<soundManager>().isInShop = true;
        else if(other.CompareTag("Player")) other.GetComponentInParent<playerSoundManager>().isInHouse = true;
    }
    private void OnTriggerExit(Collider other)
    {//tracking is customer and player out of house
        if (other.CompareTag("customer")) other.GetComponent<soundManager>().isInShop = false;
        else if (other.CompareTag("Player")) other.GetComponentInParent<playerSoundManager>().isInHouse = false;
    }
}
