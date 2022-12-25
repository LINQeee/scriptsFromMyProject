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
    public float c;
    public float d;
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
       if(!isMustGo) GameObject.Find("cashUI").GetComponent<casherGame>().stopGame(Mathf.Round((customerBalance_float - sumOfPrices) * 10) / 10 == change_float? true:false);
    }
    private void displayChange()
    {
        textChange.text = $"Change: {change_float}";
    }
    private void Update()
    {
        a = sumOfPrices;
        b = customerBalance_float;
        c = Mathf.Round((customerBalance_float - sumOfPrices)*10)/10;
        d = change_float;
    }
}
