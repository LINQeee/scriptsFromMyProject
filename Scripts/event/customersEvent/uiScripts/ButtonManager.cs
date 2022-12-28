using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonManager : customerEventData
{
    [SerializeField] private GameObject text;
    private TextMeshProUGUI textChange;
    public float a;
    public float b;
    public double c;
    public float d;
    public bool z;
    private void Start()
    {
        textChange = text.GetComponent<TextMeshProUGUI>();
    }
    public void dollarOnClick()
    {
        change_float += 1;
        displayChange();
    }
    public void fiftyCents()
    {
        change_float += 0.5f;
        displayChange();
    }
    public void tenCents()
    {
        change_float += 0.1f;
        displayChange();
    }
    public void getResult()
    {
       if(!isMustGo) GameObject.Find("cashUI").GetComponent<casherGame>().stopGame(Math.Round(10 * (customerBalance_float - sumOfPrices)) == Math.Round(change_float * 10)? true:false);
    }
    private void displayChange()
    {
        textChange.text = $"Change: {change_float}";
    }
    private void Update()
    {
        a = sumOfPrices;
        b = customerBalance_float;
        c = Math.Round(10 * (customerBalance_float - sumOfPrices));
        d = change_float;
        z = c == d;
    }
}
