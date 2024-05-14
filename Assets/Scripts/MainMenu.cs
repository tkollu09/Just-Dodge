using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject mainMenu;
    public GameObject legacyMenu;
    public InterstitialAdsButton ads;
    public void PlayGame()
    {
        int playAds = Random.Range(1, 4);
        Debug.Log(playAds);
        int sceneLoad = Random.Range(1, 7);
        SceneManager.LoadScene(sceneLoad);
        if (playAds == 3) { 
            ads.ShowAd();
            PlayerPrefs.SetInt("adsPlaying", 1);
        }
        else
        {
            PlayerPrefs.SetInt("adsPlaying", 0);
        }
    }

    public void Options()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void Back()
    {
        optionsMenu.SetActive(false);
        legacyMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Legacy()
    {
        legacyMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
}
