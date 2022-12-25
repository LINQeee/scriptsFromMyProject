using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createProducts : customerEventData
{
    [SerializeField] private GameObject[] arrayOfModels = new GameObject[39];
    [SerializeField] private float[] arrayOfCosts = new float[39];
    [SerializeField] private Texture[] arrayOftextures = new Texture[39];
    public void Start()
    {
        for(int i = 0; i< arrayOfModels.Length; i++)
        {
            arrayOfProducts[i] = gameObject.AddComponent<shoppingProductProfile>();
            arrayOfProducts[i].modelOfProduct = arrayOfModels[i];
            arrayOfProducts[i].productName = arrayOfModels[i].name;
            arrayOfProducts[i].costOfProduct = arrayOfCosts[i];
            arrayOfProducts[i].photoOfProduct = arrayOftextures[i];
        }

    }
}
