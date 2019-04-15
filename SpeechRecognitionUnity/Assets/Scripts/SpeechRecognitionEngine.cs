﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
/*
 SpeechRecognitionEngine controls the main speech recognition system for in game functions.
*/
public class SpeechRecognitionEngine : MonoBehaviour
{
    // Speech Variables
    private string[] keywords = new string[] { "a", "b", "c", "d", "pause", "yes", "no", "final answer", "show scoreboard", "scoreboard", "score", "main menu"};
    public ConfidenceLevel confidence = ConfidenceLevel.Low;
    public Text results;
    public Image target;
    public PhraseRecognizer recognizer;
    protected string word = "";
    public int questionsRight;
    GameObject finalAnswerPrompt;
    protected string finalAnswerWord = "";
    public static bool answerIsFinal = false;

    // Instance variables
    SoundController soundController = new SoundController();
    SceneManagement sceneManager = new SceneManagement();
    ScoreboardScript scoreboardScript;
    LoadQuestions loadQuestion;

    private void Start()
    {
        finalAnswerPrompt = GameObject.FindGameObjectWithTag("FinalAnswerStuff");

        if (finalAnswerPrompt != null)
        {
            finalAnswerPrompt.SetActive(false);
        }

        loadQuestion = gameObject.AddComponent(typeof(LoadQuestions)) as LoadQuestions;
        scoreboardScript = gameObject.AddComponent(typeof(ScoreboardScript)) as ScoreboardScript;

        // If keywords are populated.
        if (keywords != null)
        {
            // If recognizer is not set, set it to a new KeywordRecognizer.
            if (recognizer == null)
            {
                recognizer = new KeywordRecognizer(keywords, confidence);
            }

            // Add phrases to the list of recognized phrases.
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;

            // Start the recognizer.
            recognizer.Start();
        }

        // Print the input device to console.
        foreach (var device in Microphone.devices)
        {
            Debug.Log(device);
        }
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
        results.text = "You said: <b>" + word + "</b> ";
        WordChecker();
    }


    /**
    * Run analysis on current word recognised.
    * Takes in the word entered by user and saves it. If 'a','b','c','d' its added to finalAnswerWord.
    * If word is 'yes' or 'final answer' finalAnswerWord is used to play trhe question. 
    * Also controls menu inputs.
     */
    public void WordChecker()
    {
        switch (word)
        {
            case "a":
                Debug.Log("[Final Answer test] You first answer is :" + word);
                finalAnswerWord = word;
                answerIsFinal = true;
                soundController.playFinalSound();
                finalAnswerPrompt.SetActive(true);
                break;

            case "b":
                Debug.Log("[Final Answer test] You first answer is :" + word);
                finalAnswerWord = word;
                answerIsFinal = true;
                soundController.playFinalSound();
                finalAnswerPrompt.SetActive(true);
                break;

            case "c":
                Debug.Log("[Final Answer test] You first answer is :" + word);
                finalAnswerWord = word;
                answerIsFinal = true;
                soundController.playFinalSound();
                finalAnswerPrompt.SetActive(true);
                break;

            case "d":
                Debug.Log("[Final Answer test] You first answer is :" + word);
                finalAnswerWord = word;
                answerIsFinal = true;
                soundController.playFinalSound();
                finalAnswerPrompt.SetActive(true);
                break;

            case "show scoreboard":
                StartCoroutine(scoreboardScript.showScoreboard(3f));
                break;

            case "scoreboard":
                StartCoroutine(scoreboardScript.showScoreboard(3f));
                break;

            case "main menu":
                loadQuestion.resetQuestions();
                sceneManager.LoadMainMenu();
                break;

            case "score":
                StartCoroutine(scoreboardScript.showScoreboard(3f));
                break;

            case "quit":
                break;

            case "yes":
                if (answerIsFinal == true)
                {
                    // moved to when question is validated
                    Debug.Log("[Final Answer test] Is that your final answer:" + word);
                    Debug.Log("[Final Answer test] Your final answer:" + finalAnswerWord);
                    loadQuestion.checkAnswer(finalAnswerWord);
                    answerIsFinal = false;
                    finalAnswerPrompt.SetActive(false);
                }
                break;

            case "final answer":
                if (answerIsFinal == true)
                {
                    // moved to when question is validated
                    Debug.Log("[Final Answer test] Is that your final answer:" + word);
                    Debug.Log("[Final Answer test] Your final answer:" + finalAnswerWord);
                    loadQuestion.checkAnswer(finalAnswerWord);
                    answerIsFinal = false;
                    finalAnswerPrompt.SetActive(false);
                }
                break;

            case "no":
                soundController.stopFinalSound();
                Debug.Log("[Final Answer test] Is that your final answer:" + word);
                answerIsFinal = false;
                finalAnswerPrompt.SetActive(false);
                soundController.playEasyBackgroundMusic();
                break;
                
            case "new game":
                sceneManager.StartGame();
                break;
        }
    }
    public void OnApplicationQuit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }
    }

    /*
    (NO LONGER IN USE, KEPT FOR FUTURE EXPANSION)
    Prompt yes/no button dialog to confirm if final answwer
    */
    private void IsFinalAnswer(string word)
    {

        // if the answer is yes
        // then loadQuestion.checkAnswer(word)
        // else take in another word

    }
   


}
