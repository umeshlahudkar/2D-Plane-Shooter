using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;

    public void onPlayButtonClick()
    {
        SceneManager.LoadScene("LEVEL");
    }

    public void onQuitButtonClick()
    {
        Application.Quit();
    }

    public void onPauseButtonClick()
    {
        Time.timeScale = 0f;
        pauseScreen.SetActive(true);
    }

    public void onResumeButtonClick()
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
    }

    public void onMenuButtonClick()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    public void onRestartButtonClick()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.buildIndex);
    }



}
