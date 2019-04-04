using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class SpeechRecognitionEngine : MonoBehaviour
{
    // Variables
    private string[] keywords = new string[] { "a", "b", "c", "d", "quit", "pause", "new game", "yes", "no", "final answer", "show scoreboard", "Scoreboard"};

    public ConfidenceLevel confidence = ConfidenceLevel.Low;
    public Text results;
    public Image target;
    static PhraseRecognizer recognizer;
    protected string word = "";

    public int questionsRight;

    // Need to save the word as final answer word.
    protected string finalAnswerWord = "";
    public static bool answerIsFinal = false;
    SoundController soundController = new SoundController();

    SceneManagement sceneManager = new SceneManagement();
    ScoreboardScript scoreboardScript;
    LoadQuestions loadQuestion;

    private void Start()
    {
        loadQuestion = gameObject.AddComponent(typeof(LoadQuestions)) as LoadQuestions;
        scoreboardScript = gameObject.AddComponent(typeof(ScoreboardScript)) as ScoreboardScript;

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
                break;
            case "b":
                Debug.Log("[Final Answer test] You first answer is :" + word);
                finalAnswerWord = word;
                answerIsFinal = true;
                soundController.playFinalSound();
                break;
            case "c":
                Debug.Log("[Final Answer test] You first answer is :" + word);
                finalAnswerWord = word;
                answerIsFinal = true;
                soundController.playFinalSound();
                break;
            case "d":
                Debug.Log("[Final Answer test] You first answer is :" + word);
                finalAnswerWord = word;
                answerIsFinal = true;
                soundController.playFinalSound();
                break;
            case "show scoreboard":
                scoreboardScript.showScoreboard(3f);
                break;
            case "scoreboard":
                scoreboardScript.showScoreboard(3f);
                break;     
            case "quit":
                break;
            case "yes":
                // finalAnswerWord = word;
                if (answerIsFinal)
                {
                    // Stop the finalSOund

                    Debug.Log("[Final Answer test] Is that your final answer:" + word);
                    Debug.Log("[Final Answer test] Your final answer:" + finalAnswerWord);
                    loadQuestion.checkAnswer(finalAnswerWord);
                    answerIsFinal = false;
                }

                break;
            case "final answer":
                if (answerIsFinal)
                {
                    soundController.stopFinalSound();

                    Debug.Log("[Final Answer test] Is that your final answer:" + word);
                    Debug.Log("[Final Answer test] Your final answer:" + finalAnswerWord);
                    loadQuestion.checkAnswer(finalAnswerWord);
                    answerIsFinal = false;

                }
                break;
            case "no":
                soundController.stopFinalSound();

                Debug.Log("[Final Answer test] Is that your final answer:" + word);

                answerIsFinal = false;
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
