using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class customerEventData : MonoBehaviour
{
    protected static shoppingProductProfile[] arrayOfProducts = new shoppingProductProfile[39];
    protected static List<GameObject> listOfCars_Customers = new List<GameObject>();
    protected static List<Vector3> buyingPositions = new List<Vector3>();
    protected static List<Vector3> placesOnCasher = new List<Vector3>();
    protected readonly Vector3 casherPos = new Vector3(-62.66f, 18.12f, -263.24f);
    protected static bool isSomeoneWaitingForPay = false;
    protected static customerProfile currentCustomer;
    protected static float customerBalance_float = 0;
    protected static float change_float = 0;
    protected static float sumOfPrices = 0;
    public static bool isMustGo;
    public static bool isUIOpen;
}
