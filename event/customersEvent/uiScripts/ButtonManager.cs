using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonManager : customerEventData
{
    [SerializeField] private GameObject text;
    private TextMeshProUGUI textChange;
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
    {//closing game and sending how player passed the game
       if(!isMustGo) GameObject.Find("cashUI").GetComponent<casherGame>().stopGame(
        Math.Round(10 * (customerBalance_float - sumOfPrices)) == Math.Round(change_float * 10)? true:false
        );
    }
    private void displayChange()
    {
        textChange.text = $"Change: {change_float}";
    }

}
