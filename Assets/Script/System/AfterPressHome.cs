using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterPressHome : MonoBehaviour
{
    public static bool GameMessage = false;
    [SerializeField] GameObject Message;
    private int currentSceneIndex;

    public void Home()
    {
        Message.SetActive(true);
        Time.timeScale = 0f;
        GameMessage = true;
    }

    public void Resume()
    {
        Message.SetActive(false);
        Time.timeScale = 1f;
        GameMessage = false;
    }

    public void Yes()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        SceneManager.LoadScene(0);
        Time.timeScale = 0f;
    }
}
