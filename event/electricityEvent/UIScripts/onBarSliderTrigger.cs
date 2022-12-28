using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onBarSliderTrigger : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("mainSlider")) sliderGame.isSlidersLean = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("mainSlider")) sliderGame.isSlidersLean = false;
    }
}
