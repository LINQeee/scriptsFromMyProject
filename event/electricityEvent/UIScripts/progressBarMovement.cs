using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class progressBarMovement : MonoBehaviour
{
    
    private TextMeshProUGUI progressText;
    public static int percentProgress;
    void Start()
    {
        progressText = GetComponent<TextMeshProUGUI>();
    }

    public void moveTo(percents percent)
    {//moving progress bar according minigame progress
            switch (percent)
            {
                case percents.thirty:
                    InvokeRepeating("moveToThirty", 0, 0.01f);
                    break;
                case percents.sixty:
                    InvokeRepeating("moveToSixty", 0, 0.01f);
                    break;
                case percents.hundred:
                    InvokeRepeating("moveToHundred", 0, 0.01f);
                    break;
            }
    }

    private void moveToThirty()
    {
        if (progressText.color.r < 0.95f) progressText.color += new Color(0.005f, 0, 0, 1);
        if (GetComponent<RectTransform>().localPosition.y < -400)
        {
            GetComponent<RectTransform>().localPosition += new Vector3(0, 0.5f, 0);

            if (GetComponent<RectTransform>().localPosition.y >= -70 / 33 * (33 - percentProgress) - 400) { progressText.text = percentProgress + "%"; percentProgress++; }
        }

        if (progressText.color.r >= 0.95f && GetComponent<RectTransform>().localPosition.y >= -400) CancelInvoke("moveToThirty");
    }
    private void moveToSixty()
    {
        if (IsInvoking("moveToThirty")) return;
        if (progressText.color.g < 0.95f) progressText.color += new Color(0, 0.003f, 0, 1);
        if (GetComponent<RectTransform>().localPosition.y < 0)
        {
            GetComponent<RectTransform>().localPosition += new Vector3(0, 1f, 0);

            if (GetComponent<RectTransform>().localPosition.y >= -400 / 33 * (66 - percentProgress)) { progressText.text = percentProgress + "%"; percentProgress++; }
        }
        if (progressText.color.g >= 0.95f && GetComponent<RectTransform>().localPosition.y >= 0) CancelInvoke("moveToSixty");
    }
    private void moveToHundred()
    {
        if (IsInvoking("moveToThirty") || IsInvoking("moveToSixty")) return;
        if (progressText.color.r > 0.05f) progressText.color += new Color(-0.003f, 0, 0, 1);
        if (GetComponent<RectTransform>().localPosition.y < 400)
        {
            GetComponent<RectTransform>().localPosition += new Vector3(0, 1f, 0);

            if (GetComponent<RectTransform>().localPosition.y >= 400 - 400 / 34 * (100 - percentProgress) ) { progressText.text = percentProgress + "%"; percentProgress++; }
        }
        if (progressText.color.r <= 0.05f && GetComponent<RectTransform>().localPosition.y >= 400) CancelInvoke("moveToHundred");
    }

    public enum percents
    {
        thirty = 1,
        sixty = 2,
        hundred = 3
    }
}
