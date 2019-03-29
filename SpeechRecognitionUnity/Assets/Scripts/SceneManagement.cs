using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionsMenu;
    public GameObject LevelChooser;
    Color tempColor;

    void Start()
    {
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        LevelChooser.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void LoadMainMenu()
    {
        Debug.Log("GAME OVER");
        SceneManager.LoadScene("Menu");
        ExitGame();
    }
    public void OpenOptions()
    {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void ReturnToMenu()
    {
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        LevelChooser.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}