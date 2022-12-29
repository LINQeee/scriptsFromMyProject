using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smartphoneControl : MonoBehaviour
{
    private bool isOn;
    void Start()
    {
        isOn = false;
    }

    void Update()
    {//playing phone animations
        if (Input.GetKeyDown(KeyCode.F) && !GetComponent<Animation>().isPlaying)
        {
            if (!isOn) { GetComponent<Animation>().Play("on"); isOn = true; }
            else { GetComponent<Animation>().Play("off"); isOn = false; }
        }
    }
}
