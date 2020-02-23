using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager singleton;

    [Header("TWO MAIN Screens")]
    public GameObject menuScreen;
    public GameObject notMenuScreen;

    [Header("Screens")]
    public GameObject mainScreen;
    public GameObject shopScreen;
    public GameObject settingsScreen;

    public Image image;

    public void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else if (singleton != this)
        {
            enabled = false;
        }
    }

    public void Update()
    {
        image.sprite = Player1.singleton.skins[Player1.singleton.currentSkin].Icon;
    }

    public void Play()
    {
        
        Time.timeScale = 1;
        menuScreen.SetActive(false);
        notMenuScreen.SetActive(true);
    }




    public void OpenOptions()
    {
        mainScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }



    public void Quit() { Application.Quit(); }



    public void BackToMain()
    {
        mainScreen.SetActive(true);
        settingsScreen.SetActive(false);
    }


    public void OpenShop()
    {
        shopScreen.SetActive(true);
        mainScreen.SetActive(false);

    }
    public void CloseShop()
    {
        shopScreen.SetActive(false);
        mainScreen.SetActive(true);
    }
}
