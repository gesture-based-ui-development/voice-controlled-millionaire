using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// This class is used to manage the loading of questions from our JSON file as well
// as generating questions randomly the JSON file
[System.Serializable]
public class Question
{
    public string question;
    public string A;
    public string B;
    public string C;
    public string D;
    public string answer;
}

[System.Serializable]
public class QuestionList
{
    public Question[] questions;
}

[System.Serializable]
public class LoadQuestions : MonoBehaviour
{

    // Instance variables
    public SceneManagement sceneManager = new SceneManagement();
    public SoundController soundController = new SoundController();
    public static Question currentQuestion = new Question();
    static List<Question> fifteenQuestionArray = new List<Question>();
    public Question[] allQuestions;
    ScoreboardScript scoreboardScript;

    // String variables
    private string gameDataFileName = "questions.json";
    private string jsonString;
    private string jsonFromFile;

    // Text Variables
    TMP_Text questionText;
    public TMP_Text answerAText;
    public TMP_Text answerBText;
    public TMP_Text answerCText;
    public TMP_Text answerDText;

    // Image variables
    public Image aBoxImage;
    public Image bBoxImage;
    public Image cBoxImage;
    public Image dBoxImage;

    // Misc. variables
    public static int questionLevel = 0;

    // Dely to move to next question for 3 seconds.
    [SerializeField]
    private float nextQuestionDelay = 3f;
    private float imageFlashTime = 0.2f;

    void Awake()
    {

        aBoxImage = GameObject.Find("A").GetComponent<Image>();
        aBoxImage.color = new Color32(0, 0, 0, 255);
        bBoxImage = GameObject.Find("B").GetComponent<Image>();
        bBoxImage.color = new Color32(0, 0, 0, 255);

        cBoxImage = GameObject.Find("C").GetComponent<Image>();
        cBoxImage.color = new Color32(0, 0, 0, 255);


        dBoxImage = GameObject.Find("D").GetComponent<Image>();
        dBoxImage.color = new Color32(0, 0, 0, 255);

    }

    // Use this for initialization
    void Start()
    {
        scoreboardScript = gameObject.AddComponent(typeof(ScoreboardScript)) as ScoreboardScript;
        questionText = GameObject.Find("QuestionText").GetComponent<TMP_Text>();
        soundController.letsPlay();


        // Set the text
        allQuestions = loadQuestions();
        int randomNum = Random.Range(1, 500);
        questionLevel = 0; 

        for (int i = 0; i < 15; i++)
        {
            fifteenQuestionArray.Add(allQuestions[randomNum]);
            randomNum = Random.Range(1, 500);
        }

        StartCoroutine(advanceToNextQuestion(3f));
    }

    
    string fixJson(string value)
    {
        value = "{\"Questions\":" + value + "}";
        return value;
    }

    Question[] loadQuestions()
    {
        // Read the json and load it into a string
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);
        jsonFromFile = File.ReadAllText(filePath);

        // Parse the json into an object
        QuestionList questionList = JsonUtility.FromJson<QuestionList>(jsonFromFile);

        return questionList.questions;
    }

    void generateQuestion()
    {
        // Play a different audio clip corresponding to the diffuculty level.
        if (questionLevel <= 4)
        {
            soundController.playEasyBackgroundMusic();
        }
        else if (questionLevel <= 9)
        {
            soundController.Play32000Sound();
        }
        else if (questionLevel == 10)
        {
            soundController.Play64000Sound();
        }
        else if (questionLevel <= 12)
        {
            soundController.Play250000Sound();
        }
        else if (questionLevel == 13)
        {
            soundController.Play500000Sound();
        }
        else
        {
            soundController.playHardBackgroundMusic();
        }

        // Populate the text fields with the information from the question
        questionText = GameObject.Find("QuestionText").GetComponent<TMP_Text>();
        answerAText = GameObject.Find("AText").GetComponent<TMP_Text>();
        answerBText = GameObject.Find("BText").GetComponent<TMP_Text>();
        answerCText = GameObject.Find("CText").GetComponent<TMP_Text>();
        answerDText = GameObject.Find("DText").GetComponent<TMP_Text>();

        // Populate the currentQuestion object with information from the file
        currentQuestion.question = fifteenQuestionArray[questionLevel].question;
        currentQuestion.A = fifteenQuestionArray[questionLevel].A;
        currentQuestion.B = fifteenQuestionArray[questionLevel].B;
        currentQuestion.C = fifteenQuestionArray[questionLevel].C;
        currentQuestion.D = fifteenQuestionArray[questionLevel].D;
        currentQuestion.answer = fifteenQuestionArray[questionLevel].answer;

        Debug.Log("Correct Answer: " + currentQuestion.answer);

        questionText.text = currentQuestion.question;
        answerAText.text = currentQuestion.A;
        answerBText.text = currentQuestion.B;
        answerCText.text = currentQuestion.C;
        answerDText.text = currentQuestion.D;

    }

    public void checkAnswer(string word)
    {
        currentQuestion = fifteenQuestionArray[questionLevel];
        Debug.Log("Your Word: " + word);

        switch (word)
        {
            case "a":
                StartCoroutine(flashSelected(aBoxImage, word));
                break;
            case "b":
                StartCoroutine(flashSelected(bBoxImage, word));
                break;
            case "c":
                StartCoroutine(flashSelected(cBoxImage, word));
                break;
            case "d":
                StartCoroutine(flashSelected(dBoxImage, word));
                break;
        }


    }


    // The following IEnumators are used to add delays to events and to progress through the game
    IEnumerator advanceToNextQuestion(float timeToWait)
    {
        //Debug.Log(Time.time);
        yield return new WaitForSeconds(timeToWait);
        generateQuestion();
    }
    IEnumerator flashSelected(Image imageToFlash, string word)
    {
        yield return new WaitForSeconds(imageFlashTime);
        imageToFlash.color = new Color32(255, 165, 0, 255);
        yield return new WaitForSeconds(imageFlashTime);
        imageToFlash.color = new Color32(0, 0, 0, 255);
        yield return new WaitForSeconds(imageFlashTime);
        imageToFlash.color = new Color32(255, 165, 0, 255);
        yield return new WaitForSeconds(imageFlashTime);
        imageToFlash.color = new Color32(0, 0, 0, 255);
        yield return new WaitForSeconds(imageFlashTime);
        imageToFlash.color = new Color32(255, 165, 0, 255);
        yield return new WaitForSeconds(3);

        if (currentQuestion.answer.ToLower() == word.ToLower())
        {
            soundController.stopFinalSound();
            soundController.playRightAnswer();
            questionLevel++;

            StartCoroutine(flashCorrect(imageToFlash));
            // here is were we must implement a pop up to show money board as level increases
            Debug.Log("[DEBUG] Correct answer you have now reached level :" + (questionLevel + 1));
        }
        else if (currentQuestion.answer.ToLower() != word.ToLower())
        {
            StartCoroutine(flashIncorrect(imageToFlash));
        }
    }
    IEnumerator flashCorrect(Image imageToFlash)
    {
        yield return new WaitForSeconds(imageFlashTime);
        imageToFlash.color = new Color32(124, 252, 0, 255);
        yield return new WaitForSeconds(imageFlashTime);
        imageToFlash.color = new Color32(0, 0, 0, 255);
        yield return new WaitForSeconds(imageFlashTime);
        imageToFlash.color = new Color32(124, 252, 0, 255);
        yield return new WaitForSeconds(imageFlashTime);
        imageToFlash.color = new Color32(0, 0, 0, 255);
        yield return new WaitForSeconds(imageFlashTime);
        imageToFlash.color = new Color32(124, 252, 0, 255);
        yield return new WaitForSeconds(imageFlashTime);
        imageToFlash.color = new Color32(0, 0, 0, 255);
        StartCoroutine(scoreboardScript.showScoreboard(3f));
        StartCoroutine(advanceToNextQuestion(0.5f));

    }
    IEnumerator flashIncorrect(Image imageToFlash)
    {
        soundController.stopFinalSound();

        soundController.playWrongAnswer();

        yield return new WaitForSeconds(0.5f);
        imageToFlash.color = new Color32(255, 0, 0, 255);
        yield return new WaitForSeconds(0.5f);
        imageToFlash.color = new Color32(0, 0, 0, 255);
        yield return new WaitForSeconds(0.5f);
        imageToFlash.color = new Color32(255, 0, 0, 255);
        yield return new WaitForSeconds(0.5f);
        imageToFlash.color = new Color32(0, 0, 0, 255);
        yield return new WaitForSeconds(0.5f);
        imageToFlash.color = new Color32(255, 0, 0, 255);
        Debug.Log("Incorrect answer");
        //StartCoroutine(scoreboardScript.showScoreboardAtEnd(5f));
        resetQuestions();
        sceneManager.LoadMainMenu();
    }

    // When you lose, reset the game state
    public void resetQuestions()
    {
        int randomNum = Random.Range(1, 500);
        questionLevel = 0; 
        fifteenQuestionArray.Clear();        

        for (int i = 0; i < 15; i++)
        {
            fifteenQuestionArray.Add(allQuestions[randomNum]);
            randomNum = Random.Range(1, 500);
        }
    }
}

