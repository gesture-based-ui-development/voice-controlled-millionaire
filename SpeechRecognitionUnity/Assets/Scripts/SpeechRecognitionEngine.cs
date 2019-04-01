using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class SpeechRecognitionEngine : MonoBehaviour
{
    // Variables
    private string[] keywords = new string[] { "a", "b", "c", "d", "quit", "pause", "new game" };
    public ConfidenceLevel confidence = ConfidenceLevel.Low;
    public Text results;
    public Image target;
    static PhraseRecognizer recognizer;
    protected string word = "";
    public int questionsRight;

    SceneManagement sceneManager = new SceneManagement();
    //LoadQuestions loadQuestion = new LoadQuestions();
    LoadQuestions loadQuestion;

    private void Start()
    {
        loadQuestion = gameObject.AddComponent(typeof(LoadQuestions)) as LoadQuestions;

        if (keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
        }
        foreach (var device in Microphone.devices)
        {
            Debug.Log(device);
        }
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
        results.text = "You said: <b>" + word + "</b>";
        WordChecker();
    }

    public void WordChecker()
    {
        switch (word)
        {
            case "a":
                loadQuestion.checkAnswer(word);
                break;
            case "b":
                loadQuestion.checkAnswer(word);
                break;
            case "c":
                loadQuestion.checkAnswer(word);
                break;
            case "d":
                loadQuestion.checkAnswer(word);
                break;
            case "quit":
                break;
            case "new game":
                sceneManager.StartGame();
                break;
        }
    }
    private void OnApplicationQuit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }
    }


}
