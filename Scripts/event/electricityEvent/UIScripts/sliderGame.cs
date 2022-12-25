using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class sliderGame : electricityEventData
{
    [SerializeField] private RectTransform mainSlider;
    [SerializeField] private RectTransform onBarSlider;
    [SerializeField] private Image vignette;
    public static bool isSlidersLean;
    private float mainMinPos = -647;
    private float mainMaxPos = 647;
    private float onBarMinPos = -666;
    private float onBarMaxPos = 666;
    private goTo mainSliderDirection;
    private goTo onBarSliderDirection;
    private float speed;
    private int goodAttempts;
    public static bool isPlaying;
    [SerializeField] private TextMeshProUGUI textProgress;
    [SerializeField] private GameObject player;
    public void startPlaying()
    {
        progressBarMovement.percentProgress = 1;
        textProgress.GetComponent<progressBarMovement>().CancelInvoke();
        playerMovement.isMovementBlocked = true;
        isPlaying = true;
        speed = 1f;
        goodAttempts = 0;
        onBarSlider.localScale = new Vector3(1f, 1f, 1f);
        textProgress.text = "0%";
        textProgress.color = new Color(0, 0, 0);
        textProgress.GetComponent<RectTransform>().localPosition = new Vector3(-236, -470, 0);
        InvokeRepeating("moveSliders", 0, 0.0001f);
        GetComponent<Animation>().PlayQueued("showUp");
    }

    private void Update()
    {
        if (isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isSlidersLean)
                {
                    vignette.color = new Color(0, 1, 0, 0);
                    InvokeRepeating("vignetteShowUp", 0, 0.01f);
                    goodAttempts++;
                    if (goodAttempts != 3) onBarSlider.localScale -= new Vector3(onBarSlider.localScale.x / 2, 0, 0);
                    textProgress.GetComponent<progressBarMovement>().moveTo((progressBarMovement.percents)goodAttempts);

                    if (goodAttempts == 3)
                    {
                        CancelInvoke("moveSliders");
                        InvokeRepeating("checkForEnd", 0, 1);
                    }
                    speed *= 2.5f;
                }
                else
                {
                    vignette.color = new Color(1, 0, 0, 0);
                    InvokeRepeating("vignetteShowUp", 0, 0.01f);
                    GetComponent<Animation>().PlayQueued("showDown");
                    playerMovement.isMovementBlocked = false;
                    isPlaying = false;
                    CancelInvoke("moveSliders");
                }
            }
        }
    }

    private void checkForEnd()
    {
        if (textProgress.text == "100%")
        {
            GetComponent<Animation>().PlayQueued("showDown");
            playerMovement.isMovementBlocked = false;
            isPlaying = false;
            isNeedFillFuel = false; 
            CancelInvoke();
        }
    }

    private void vignetteShowUp()
    {
        vignette.color += new Color(0, 0, 0, 0.02f);
        if (vignette.color.a >= 0.5f) { InvokeRepeating("vignetteShowDown", 0, 0.01f); CancelInvoke("vignetteShowUp"); }
    }
    private void vignetteShowDown()
    {
        vignette.color -= new Color(0, 0, 0, 0.02f);
        if (vignette.color.a <= 0) CancelInvoke("vignetteShowDown"); ;
    }

    private enum goTo
    {
        left,
        right
    }
    private void moveSliders()
    {
        if (onBarSlider.localPosition.x <= onBarMinPos) onBarSliderDirection = goTo.right;
        else if (onBarSlider.localPosition.x >= onBarMaxPos) onBarSliderDirection = goTo.left;

        if (mainSlider.localPosition.x <= mainMinPos) mainSliderDirection = goTo.right;
        else if (mainSlider.localPosition.x >= mainMaxPos) mainSliderDirection = goTo.left;

        if (mainSliderDirection == goTo.left) mainSlider.localPosition -= new Vector3(speed, 0, 0);
        else mainSlider.localPosition += new Vector3(speed, 0, 0);

        if (onBarSliderDirection == goTo.left) onBarSlider.localPosition -= new Vector3(speed / 3, 0, 0);
        else onBarSlider.localPosition += new Vector3(speed / 3, 0, 0);
    }
}
