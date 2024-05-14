using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    public cherryColliderScript script;
    public GameObject player;

    public static bool GameIsPaused = false;

    // Update is called once per frame
    public void Resume()
    {
        //player.transform.position = playerPos;
        player.transform.parent = null;
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseButton.SetActive(true);
    }
    public void Pause()
    {
        //player.transform.position = Vector3.zero;
        player.transform.parent = null;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        pauseButton.SetActive(false);
    }
    public void LoadMenu()
    {
        if (!PlayerPrefs.HasKey("highScore") && acornColliderScript.lives != 0)
        {
            PlayerPrefs.SetInt("highScore", script.score);
        }
        else
        {
            if (script.score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", script.score);
            }
        }
        Time.timeScale = 1f;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        //StartCoroutine(SceneSwitch());
    }
    public void restart()
    {
        Time.timeScale = 1f;
        int loadScene = Random.Range(1,7);
        SceneManager.LoadScene(loadScene, LoadSceneMode.Single);
        //StartCoroutine(SceneReload());
    }
    IEnumerator SceneSwitch()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Additive);
        yield return null;
        SceneManager.UnloadSceneAsync(1);
    }
    IEnumerator SceneReload()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Additive);
        yield return null;
        SceneManager.UnloadSceneAsync(1);
    }

    public void QuitGame()
    {
        player.transform.parent = null;
        if (!PlayerPrefs.HasKey("highScore") && acornColliderScript.lives != 0)
        {
            PlayerPrefs.SetInt("highScore", script.score);
        }
        else
        {
            if (script.score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", script.score);
            }
        }
        Application.Quit();
    }

    public void settings()
    {   
        pauseMenuUI.SetActive(false);   
        settingsMenuUI.SetActive(true);
    }
    
}
