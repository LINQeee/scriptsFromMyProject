using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundPhoneChange : MonoBehaviour
{
    [SerializeField] private AudioClip onSound;
    [SerializeField] private AudioClip offSound;
    [SerializeField] private GameObject player;
    private void soundOn()
    {
       player.GetComponent<AudioSource>().PlayOneShot(onSound);
    }
    private void soundOff()
    {
        player.GetComponent<AudioSource>().PlayOneShot(offSound);
    }
}
