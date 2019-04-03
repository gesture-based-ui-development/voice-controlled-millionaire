using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class SpeechRecognitionEngine : MonoBehaviour
{
    // Variables
    private string[] keywords = new string[] { "a", "b", "c", "d", "quit", "pause", "new game", "yes", "no", "final answer" };
    public ConfidenceLevel confidence = ConfidenceLevel.Low;
    public Text results;
    public Image target;
    static PhraseRecognizer recognizer;
    protected string word = "";

    public int questionsRight;

    // Need to save the word as final answer word.
    protected string finalAnswerWord = "";
    protected bool answerIsFinal = false;

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
                if (answerIsFinal)
                {
                    loadQuestion.checkAnswer(word);
                }

                break;
            case "b":
                if (answerIsFinal)
                {
                    loadQuestion.checkAnswer(word);
                }

                break;
            case "c":
                if (answerIsFinal)
                {
                    loadQuestion.checkAnswer(word);
                }

                break;
            case "d":
                if (answerIsFinal)
                {
                    loadQuestion.checkAnswer(word);
                }

                break;

            case "quit":
                break;
            case "yes":
                finalAnswerWord = word;
                answerIsFinal = true;
                break;
            case "final answer":
                answerIsFinal = true;
                break;
            case "no":
                answerIsFinal = false;
                break;
            case "new game":
                sceneManager.StartGame();
                break;
/*
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
                .checkAnswer(word);
                break;

            case "quit":
                break;
                break;
            case "new game":
                sceneManager.StartGame();
                break;

*/
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

        /*
         * Prompt yes/no button dialog to confirm if final answwer
        */
        private void IsFinalAnswer(string word)
        {
            // if the answer is yes
            // then loadQuestion.checkAnswer(word)
            // else take in another word

        }


    }
