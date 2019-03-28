using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class SpeechRecognitionEngine : MonoBehaviour
{   
    // Variables
    private string[] keywords = new string[] { "a", "b", "c", "d" , "quit", "pause", "new game"};
    public ConfidenceLevel confidence = ConfidenceLevel.Low;
    public Text results;
    public Image target;
    protected PhraseRecognizer recognizer;
    protected string word = "right";

    SceneManagement sceneManager = new SceneManagement();

    private void Start()
    {
        if (keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
        }
        foreach(var device in Microphone.devices)
        {
            Debug.Log(device);
        }
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
        results.text = "You said: <b>" + word + "</b>";
    }

    private void Update()
    {
        switch (word)
        {
            case "a":
                break;
            case "b":
                break;
            case "c":
                break;
            case "d":
                break;
            case "quit":
                break;
            case "New game":
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
