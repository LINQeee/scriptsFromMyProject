using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class cleaningProgress : MonoBehaviour
{
    public int cleaningPoints { set; get;}
    private float opacity;
    public void resetPoints()
    {   
        cleaningPoints = 3;
        opacity = 1;
        GetComponent<Renderer>().material.SetColor("_BaseColor", new Color(1, 1, 1, opacity));
    }

    public void wipe()
    {
        cleaningPoints -= 1;
        InvokeRepeating("setTexture", 0, 0.09f);setTexture();
    }

    private void setTexture()
    {
        switch (cleaningPoints)
        {
            case 0:
                opacity -= 0.01f;
                GetComponent<Renderer>().material.SetColor("_BaseColor", new Color(1, 1, 1, opacity));
                if (opacity <= 0)
                {   
                    cleaningBroomEvent.cleanOneDirt();
                    CancelInvoke();
                }
                break;
            case 1:
                opacity -= 0.01f;
                GetComponent<Renderer>().material.SetColor("_BaseColor", new Color(1, 1, 1, opacity));
                if (opacity <= 0.33f) CancelInvoke();
                break;
            case 2:
                opacity -= 0.01f;
                GetComponent<Renderer>().material.SetColor("_BaseColor", new Color(1, 1, 1, opacity));
                if (opacity <= 0.77f) CancelInvoke();
                break;
        }
    }
}
