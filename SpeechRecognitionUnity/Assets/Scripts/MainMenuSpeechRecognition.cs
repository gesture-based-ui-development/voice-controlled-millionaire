using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

// This class is responsible for handling Speech Recognition within the Main Menu
public class MainMenuSpeechRecognition : MonoBehaviour
{
    // Instance variables
    SoundController soundController = new SoundController();
    SceneManagement sceneManager = new SceneManagement();

    // Speech Variables
    private string[] menuKeywords = new string[] { "play game", "new game", "play", "quit", "exit" };
    public ConfidenceLevel confidence = ConfidenceLevel.Low;
    public Text results;
    public PhraseRecognizer mainMenuRecognizer;
    protected string word = "";


    private void Start()
    {
        if (menuKeywords != null)
        {
            if (mainMenuRecognizer == null)
            {
                mainMenuRecognizer = new KeywordRecognizer(menuKeywords, confidence);
            }
            mainMenuRecognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            mainMenuRecognizer.Start();
        }
        foreach (var device in Microphone.devices)
        {
            Debug.Log(device);
        }
        SoundManager.Instance.PlayMenu();
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
            case "quit":
                Application.Quit();
                break;
            case "new game":
                sceneManager.StartGame();
                destroyRecognizer();
                mainMenuRecognizer.Stop();
                SoundManager.Instance.StopMenuMusic();
                break;
            case "play":
                sceneManager.StartGame();
                destroyRecognizer();
                mainMenuRecognizer.Stop();
                SoundManager.Instance.StopMenuMusic();
                break;
            case "play game":
                sceneManager.StartGame();
                destroyRecognizer();
                mainMenuRecognizer.Stop();
                SoundManager.Instance.StopMenuMusic();
                break;
        }
    }
    private void OnApplicationQuit()
    {
        if (mainMenuRecognizer != null && mainMenuRecognizer.IsRunning)
        {
            mainMenuRecognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            mainMenuRecognizer.Stop();
        }
    }
    private void destroyRecognizer()
    {
        if (mainMenuRecognizer != null && mainMenuRecognizer.IsRunning)
        {
            mainMenuRecognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            mainMenuRecognizer.Stop();
        }
    }



}
