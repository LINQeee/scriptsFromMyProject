using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class casherGame : customerEventData
{   
    [SerializeField] private GameObject scrollArea;
    [SerializeField] private GameObject cashBalance;
    private bool isMustMoveCamera = false;
    private TextMeshProUGUI change;
    private TextMeshProUGUI customerBalance;
    private List<GameObject> UIProductsList = new List<GameObject>();
    private Vector3 startPos;
    private Quaternion startRot;
    private Vector3 cameraCashGamePos = new Vector3(-60, 19.4f, -263.3f);
    private Quaternion cameraCashGameRotation = Quaternion.Euler(45, -90, 0);

    private void Start()
    {//fill in main values and creating list of photocards in UI
        change = cashBalance.GetComponent<RectTransform>().GetChild(0).GetComponent<TextMeshProUGUI>();
        customerBalance = cashBalance.GetComponent<RectTransform>().GetChild(1).GetComponent<TextMeshProUGUI>();
        foreach(RectTransform tran in scrollArea.GetComponent<RectTransform>().GetChild(0))
        {
            UIProductsList.Add(tran.gameObject);
            tran.gameObject.SetActive(false);
        }
    }

    public void startGame()
    {//blocking movement for player
        playerMovement.isMovementBlocked = true;
        startRot = Camera.main.transform.rotation;
        startPos = Camera.main.transform.position;
        InvokeRepeating("cameraMoveTowards", 0, 0.01f);
        change.text = $"Change: {change_float}";
        customerBalance.text = $"Customer: {customerBalance_float}";
        if(currentCustomer.listOfId.Count > 3) scrollArea.GetComponent<RectTransform>().GetChild(0).gameObject.GetComponent<shoppingUIProducts>().bigger();
        for(int i = 0; i < currentCustomer.listOfId.Count; i++)
        {
            UIProductsList[i].SetActive(true);
            UIProductsList[i].GetComponent<RectTransform>().GetChild(0).GetComponent<TextMeshProUGUI>().text = $"{arrayOfProducts[currentCustomer.listOfId[i]].productName} - {arrayOfProducts[currentCustomer.listOfId[i]].costOfProduct}";
            UIProductsList[i].GetComponent<RawImage>().texture = arrayOfProducts[currentCustomer.listOfId[i]].photoOfProduct;
        }
        GetComponent<Animation>().PlayQueued("showUp");
    }
    public void stopGame(bool isCorrect)
    {   
        isMustGo = true;
        isSomeoneWaitingForPay = false;
        GetComponent<Animation>().PlayQueued("showDown");
        if (currentCustomer.listOfId.Count > 3) scrollArea.GetComponent<RectTransform>().GetChild(0).gameObject.GetComponent<shoppingUIProducts>().smaller();
        if (isCorrect) Debug.Log("well done");
        else Debug.Log("bad");
        isUIOpen = false;
        isMustMoveCamera = true;
    }
    private void cameraMoveTowards()
    {
        if (Vector3.Distance(Camera.main.transform.position, cameraCashGamePos) <= 0.001f && Quaternion.Angle(Camera.main.transform.rotation, cameraCashGameRotation) < 0.001f)
        {
            Camera.main.transform.rotation = cameraCashGameRotation;
            Camera.main.transform.position = cameraCashGamePos;
            CancelInvoke("cameraMoveTowards");
            InvokeRepeating("cameraMoveBackwards", 0, 0.01f);
        }

        if (Vector3.Distance(Camera.main.transform.position, cameraCashGamePos) > 0.001f)
        {
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, cameraCashGamePos, 0.03f);
        }
        Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, cameraCashGameRotation, 0.03f);
    }
    private void cameraMoveBackwards()
    { 
        if (isMustMoveCamera)
        {
            if (Vector3.Distance(Camera.main.transform.position, startPos) <= 0.001f && Quaternion.Angle(Camera.main.transform.rotation, startRot) < 0.001f)
            {
                Camera.main.transform.rotation = startRot;
                Camera.main.transform.position = startPos;
                playerMovement.isMovementBlocked = false;

                CancelInvoke("cameraMoveBackwards");
            }

            if (Vector3.Distance(Camera.main.transform.position, startPos) > 0.001f)
            {
                Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, startPos, 0.03f);
            }
            Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, startRot, 0.03f);
        }
    }
}
