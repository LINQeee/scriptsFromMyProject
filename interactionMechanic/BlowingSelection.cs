using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowingSelection : MonoBehaviour
{

    public float rColor;
    public float gColor;

    public static void setBlowing(GameObject gameObject)
    {
            var render = gameObject.GetComponent<Renderer>().materials;
            for (int i = 0; i < render.Length; i++)
            {
                render[i].SetColor("EmissiveColor", new Color(215, 25, 0));
            }
    }
    public static void stopBlowing(GameObject gameObject)
    {
            var render = gameObject.GetComponent<Renderer>().materials;
            for (int i = 0; i < render.Length; i++)
            {
                render[i].SetColor("EmissiveColor", new Color(0, 0, 0));
            }
    }
}
