using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* 
A Basic SceneManagement class to control the movement from various scenes.
 */
public class SceneManagement : MonoBehaviour
{
    public GameObject MainMenu;

    void Start()
    {
        MainMenu.SetActive(true);
    }

    /*
    Starts the main game scene and stops menu audio.
     */
    public void StartGame()
    {
        SoundManager.Instance.StopMenuMusic();
        SceneManager.LoadScene("Main");
    }

    /*
    Starts the main menu scene and starts menu audio.
    */
    public void LoadMainMenu()
    {
        SoundManager.Instance.PlayMenu();
        SceneManager.LoadScene("Menu");
    }

    /* 
    Quit the application.
     */
    public void ExitGame()
    {
        Application.Quit();
    }

}