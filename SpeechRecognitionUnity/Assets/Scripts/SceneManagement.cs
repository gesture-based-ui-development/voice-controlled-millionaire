using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject MainMenu;

    void Start()
    {
        MainMenu.SetActive(true);
    }

    public void StartGame()
    {
        SoundManager.Instance.StopMenuMusic();
        SceneManager.LoadScene("Main");
    }
    public void LoadMainMenu()
    {
        SoundManager.Instance.PlayMenu();
        SceneManager.LoadScene("Menu");
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}