using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class customerEvent : customerEventData
{
    
    

    public static void Setup()
    {
        buyingPositions.Add(new Vector3(-67, 18.32f, -264.1f));
        buyingPositions.Add(new Vector3(-67, 18.32f, -266.9f));
        buyingPositions.Add(new Vector3(-73, 18.32f, -266.9f));
        buyingPositions.Add(new Vector3(-73, 18.32f, -264.2f));

        placesOnCasher.Add(new Vector3(-61.6f, 18.58f, -262.9f));
        placesOnCasher.Add(new Vector3(-61.6f, 18.58f, -263.33f));
        placesOnCasher.Add(new Vector3(-61.6f, 18.58f, -263.75f));
        placesOnCasher.Add(new Vector3(-61.1f, 18.58f, -263.75f));
        placesOnCasher.Add(new Vector3(-61.1f, 18.58f, -263.33f));
        placesOnCasher.Add(new Vector3(-61.1f, 18.58f, -263.9f));

        foreach(Transform tran in GameObject.Find("Cars").transform)
        {
            listOfCars_Customers.Add(tran.gameObject);
        }
        listOfCars_Customers[new System.Random().Next(listOfCars_Customers.Count)].
            GetComponent<arriveCustomer>().arrive();

    }



 
}
