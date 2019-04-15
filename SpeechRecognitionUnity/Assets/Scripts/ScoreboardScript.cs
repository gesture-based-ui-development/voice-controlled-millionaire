using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/* 
 ScoreboardScript is used to control all aspects of the scoreboard.
 */
public class ScoreboardScript : MonoBehaviour
{

    // Image variables
    Image scoreboardQ0;
    Image scoreboardQ1;
    Image scoreboardQ2;
    Image scoreboardQ3;
    Image scoreboardQ4;
    Image scoreboardQ5;
    Image scoreboardQ6;
    Image scoreboardQ7;
    Image scoreboardQ8;
    Image scoreboardQ9;
    Image scoreboardQ10;
    Image scoreboardQ11;
    Image scoreboardQ12;
    Image scoreboardQ13;
    Image scoreboardQ14;
    Image scoreboardQ15;

    // Instance variables
    LoadQuestions loadQuestions = new LoadQuestions();
    SceneManagement sceneManager = new SceneManagement();

    void Awake()
    {
        scoreboardQ0 = GameObject.Find("MainGameCanvas/Scoreboard/SCORENO").GetComponent<Image>();
        scoreboardQ1 = GameObject.Find("MainGameCanvas/Scoreboard/score1").GetComponent<Image>();
        scoreboardQ2 = GameObject.Find("MainGameCanvas/Scoreboard/score2").GetComponent<Image>();
        scoreboardQ3 = GameObject.Find("MainGameCanvas/Scoreboard/score3").GetComponent<Image>();
        scoreboardQ4 = GameObject.Find("MainGameCanvas/Scoreboard/score4").GetComponent<Image>();
        scoreboardQ5 = GameObject.Find("MainGameCanvas/Scoreboard/score5").GetComponent<Image>();
        scoreboardQ6 = GameObject.Find("MainGameCanvas/Scoreboard/score6").GetComponent<Image>();
        scoreboardQ7 = GameObject.Find("MainGameCanvas/Scoreboard/score7").GetComponent<Image>();
        scoreboardQ8 = GameObject.Find("MainGameCanvas/Scoreboard/score8").GetComponent<Image>();
        scoreboardQ9 = GameObject.Find("MainGameCanvas/Scoreboard/score9").GetComponent<Image>();
        scoreboardQ10 = GameObject.Find("MainGameCanvas/Scoreboard/score9").GetComponent<Image>();
        scoreboardQ11 = GameObject.Find("MainGameCanvas/Scoreboard/score11").GetComponent<Image>();
        scoreboardQ12 = GameObject.Find("MainGameCanvas/Scoreboard/score12").GetComponent<Image>();
        scoreboardQ13 = GameObject.Find("MainGameCanvas/Scoreboard/score13").GetComponent<Image>();
        scoreboardQ14 = GameObject.Find("MainGameCanvas/Scoreboard/score14").GetComponent<Image>();
        scoreboardQ15 = GameObject.Find("MainGameCanvas/Scoreboard/score15").GetComponent<Image>();

        scoreboardQ0.enabled = false;
        scoreboardQ1.enabled = false;
        scoreboardQ2.enabled = false;
        scoreboardQ3.enabled = false;
        scoreboardQ4.enabled = false;
        scoreboardQ5.enabled = false;
        scoreboardQ6.enabled = false;
        scoreboardQ7.enabled = false;
        scoreboardQ8.enabled = false;
        scoreboardQ9.enabled = false;
        scoreboardQ10.enabled = false;
        scoreboardQ11.enabled = false;
        scoreboardQ12.enabled = false;
        scoreboardQ13.enabled = false;
        scoreboardQ14.enabled = false;
        scoreboardQ15.enabled = false;
    }

    // The following IEnumerators handle showing the scoreboard
    public IEnumerator showScoreboard(float timeToShow)
    {
        Debug.Log("insdie func");

        if (LoadQuestions.questionLevel == 0)
        {
            scoreboardQ0.enabled = true;
            yield return new WaitForSeconds(timeToShow);
            scoreboardQ0.enabled = false;
        }
        if (LoadQuestions.questionLevel == 1)
        {
            scoreboardQ2.enabled = true;
            yield return new WaitForSeconds(timeToShow);
            scoreboardQ2.enabled = false;
        }
        if (LoadQuestions.questionLevel == 2)
        {
            scoreboardQ3.enabled = true;
            yield return new WaitForSeconds(timeToShow);
            scoreboardQ3.enabled = false;
        }
        if (LoadQuestions.questionLevel == 3)
        {
            scoreboardQ4.enabled = true;
            yield return new WaitForSeconds(timeToShow);
            scoreboardQ4.enabled = false;
        }
        if (LoadQuestions.questionLevel == 4)
        {
            scoreboardQ5.enabled = true;
            yield return new WaitForSeconds(timeToShow);
            scoreboardQ5.enabled = false;
        }
        if (LoadQuestions.questionLevel == 5)
        {
            scoreboardQ6.enabled = true;
            yield return new WaitForSeconds(timeToShow);
            scoreboardQ6.enabled = false;
        }
        if (LoadQuestions.questionLevel == 6)
        {
            scoreboardQ7.enabled = true;
            yield return new WaitForSeconds(timeToShow);
            scoreboardQ7.enabled = false;
        }
        if (LoadQuestions.questionLevel == 7)
        {
            scoreboardQ8.enabled = true;
            yield return new WaitForSeconds(timeToShow);
            scoreboardQ8.enabled = false;
        }
        if (LoadQuestions.questionLevel == 8)
        {
            scoreboardQ9.enabled = true;
            yield return new WaitForSeconds(timeToShow);
            scoreboardQ9.enabled = false;
        }
        if (LoadQuestions.questionLevel == 9)
        {
            scoreboardQ10.enabled = true;
            yield return new WaitForSeconds(timeToShow);
            scoreboardQ10.enabled = false;
        }
        if (LoadQuestions.questionLevel == 10)
        {
            scoreboardQ11.enabled = true;
            yield return new WaitForSeconds(timeToShow);
            scoreboardQ11.enabled = false;
        }
        if (LoadQuestions.questionLevel == 11)
        {
            scoreboardQ12.enabled = true;
            yield return new WaitForSeconds(timeToShow);
            scoreboardQ12.enabled = false;
        }
        if (LoadQuestions.questionLevel == 12)
        {
            scoreboardQ13.enabled = true;
            yield return new WaitForSeconds(timeToShow);
            scoreboardQ13.enabled = false;
        }
        if (LoadQuestions.questionLevel == 13)
        {
            scoreboardQ14.enabled = true;
            yield return new WaitForSeconds(timeToShow);
            scoreboardQ14.enabled = false;
        }
        if (LoadQuestions.questionLevel == 14)
        {
            scoreboardQ15.enabled = true;
            yield return new WaitForSeconds(timeToShow);
            scoreboardQ15.enabled = false;
        }
    }

    /*
    Displays the scoreboard for a set amount of time.
     */
    public IEnumerator showScoreboardAtEnd(float timeToShow)
    {
        Debug.Log("inside showScoreboardAtEnd func");

        if (LoadQuestions.questionLevel == 0)
        {
            scoreboardQ0.enabled = true;
            yield return new WaitForSeconds(timeToShow);
            scoreboardQ0.enabled = false;
        }
        if (LoadQuestions.questionLevel == 1)
        {
            scoreboardQ2.enabled = true;
            yield return new WaitForSeconds(timeToShow);
            scoreboardQ2.enabled = false;
        }
        if (LoadQuestions.questionLevel == 2)
        {
            scoreboardQ3.enabled = true;
            yield return new WaitForSeconds(timeToShow);
            scoreboardQ3.enabled = false;
        }
        if (LoadQuestions.questionLevel == 3)
        {
            scoreboardQ4.enabled = true;
            yield return new WaitForSeconds(timeToShow);
            scoreboardQ4.enabled = false;
        }
        if (LoadQuestions.questionLevel == 4)
        {
            scoreboardQ5.enabled = true;
            yield return new WaitForSeconds(timeToShow);
            scoreboardQ5.enabled = false;
        }
        if (LoadQuestions.questionLevel == 5)
        {
            scoreboardQ6.enabled = true;
            yield return new WaitForSeconds(timeToShow);
            scoreboardQ6.enabled = false;
        }
        if (LoadQuestions.questionLevel == 6)
        {
            scoreboardQ7.enabled = true;
            yield return new WaitForSeconds(timeToShow);
            scoreboardQ7.enabled = false;
        }
        if (LoadQuestions.questionLevel == 7)
        {
            scoreboardQ8.enabled = true;
            yield return new WaitForSeconds(timeToShow);
            scoreboardQ8.enabled = false;
        }
        if (LoadQuestions.questionLevel == 8)
        {
            scoreboardQ9.enabled = true;
            yield return new WaitForSeconds(timeToShow);
            scoreboardQ9.enabled = false;
        }
        if (LoadQuestions.questionLevel == 9)
        {
            scoreboardQ10.enabled = true;
            yield return new WaitForSeconds(timeToShow);
            scoreboardQ10.enabled = false;
        }
        if (LoadQuestions.questionLevel == 10)
        {
            scoreboardQ11.enabled = true;
            yield return new WaitForSeconds(timeToShow);
            scoreboardQ11.enabled = false;
        }
        if (LoadQuestions.questionLevel == 11)
        {
            scoreboardQ12.enabled = true;
            yield return new WaitForSeconds(timeToShow);
            scoreboardQ12.enabled = false;
        }
        if (LoadQuestions.questionLevel == 12)
        {
            scoreboardQ13.enabled = true;
            yield return new WaitForSeconds(timeToShow);
            scoreboardQ13.enabled = false;
        }
        if (LoadQuestions.questionLevel == 13)
        {
            scoreboardQ14.enabled = true;
            yield return new WaitForSeconds(timeToShow);
            scoreboardQ14.enabled = false;
        }
        if (LoadQuestions.questionLevel == 14)
        {
            scoreboardQ15.enabled = true;
            yield return new WaitForSeconds(timeToShow);
            scoreboardQ15.enabled = false;
        }
        loadQuestions.resetQuestions();
        sceneManager.LoadMainMenu();
    }
}
