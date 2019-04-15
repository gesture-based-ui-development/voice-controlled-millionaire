using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 This class handles the fading in and out of the splash screen.
*/
public class SplashFade : MonoBehaviour
{
    // Variables
    public Image splashImage;
    public bool isSplashScreen = false;
    Scene currentScene;
    string currentSceneName;
    public bool isDead;
    public bool isTitleScreen;

    IEnumerator Start()
    {
        if (isSplashScreen == true)
        {
            splashImage.canvasRenderer.SetAlpha(0.0f);

            FadeIn();

            yield return new WaitForSeconds(2.5f);

            FadeOut();

            yield return new WaitForSeconds(2.5f);

            SceneManager.LoadScene("Menu");
        }

        if (isTitleScreen == true)
        {
            splashImage.canvasRenderer.SetAlpha(0.0f);

            FadeIn();

            yield return new WaitForSeconds(2.5f);

            FadeOut();

            yield return new WaitForSeconds(2.5f);
            splashImage.enabled = false;
        }
    }

    /* 
    Fade in the splash Image.
     */
    void FadeIn()
    {
        splashImage.CrossFadeAlpha(1.0f, 1.5f, false);
    }

    /* 
    Fade out the splash Image.
     */
    void FadeOut()
    {
        splashImage.CrossFadeAlpha(0f, 2.5f, false);
    }

}

