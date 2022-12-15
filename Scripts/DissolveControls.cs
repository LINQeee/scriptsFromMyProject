using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveControl : MonoBehaviour
{
    List<Material> materials = new List<Material>();
    private float number;
    void Start()
    {
        var renders = GetComponents<Renderer>();
        for (int i = 0; i < renders.Length; i++)
        {
            materials.AddRange(renders[i].materials);
        }
        number = 0;
    }

    private void makeInvisible()
    {
        if (number >= 1)
        {
            number = 1;
            CancelInvoke();
        }
        for (int i = 0; i < materials.Count; i++)
        {
            materials[i].SetFloat("_Dissolve", number);
        }
        number += 0.001f;
    }
    private void makeVisible()
    {
        if (number <= 0)
        {
            number = 0;
            CancelInvoke();
        }
        for (int i = 0; i < materials.Count; i++)
        {
            materials[i].SetFloat("_Dissolve", number);
        }
        number -= 0.001f;
    }

}

