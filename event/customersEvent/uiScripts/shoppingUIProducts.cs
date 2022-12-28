using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoppingUIProducts : MonoBehaviour
{
    [SerializeField] List<GameObject> listOfChildren = new List<GameObject>();

    public void bigger()
    {
            foreach(var item in listOfChildren)
            {
                item.transform.SetParent(null);
            }
            GetComponent<RectTransform>().localScale += new Vector3(0, 1.01f, 0);
            GetComponent<RectTransform>().position += new Vector3(0, -19 * 10.1f, 0);
            foreach(var item in listOfChildren)
            {
                item.GetComponent<RectTransform>().SetParent(GetComponent<RectTransform>());
            }
    }
    public void smaller()
    {
            foreach (var item in listOfChildren)
            {
                item.transform.SetParent(null);
            }
            GetComponent<RectTransform>().localScale -= new Vector3(0, 1.01f, 0);
            GetComponent<RectTransform>().position -= new Vector3(0, -19 * 10.1f, 0);
            foreach (var item in listOfChildren)
            {
                item.GetComponent<RectTransform>().SetParent(GetComponent<RectTransform>());
            }
    }
 
}
