using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{//TODO make difficult mechanic here
//TODO settings play quit buttons
    public GameObject menu;
    public GameObject settingMenu;
    public void playButton_click()
    {
        SceneManager.LoadScene(1);
    }
    public void setSettings()
    {
        menu.SetActive(false);
        settingMenu.SetActive(true);
    }
}
