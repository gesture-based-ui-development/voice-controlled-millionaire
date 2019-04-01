using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
    static List<Question> tenQuestionArray = new List<Question>();
    public Question[] allQuestions;

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
    public int questionLevel = 0;

    // Dely to move to next question for 3 seconds.
    [SerializeField]
    private float nextQuestionDelay = 3f;
    private float imageFlashTime = 0.2f;

    void Awake()
    {
        aBoxImage = GameObject.Find("A").GetComponent<Image>();
        bBoxImage = GameObject.Find("B").GetComponent<Image>();
        cBoxImage = GameObject.Find("C").GetComponent<Image>();
        dBoxImage = GameObject.Find("D").GetComponent<Image>();
    }

    // Use this for initialization
    void Start()
    {
        // Play start audio clip on game start.
        // SoundManager.Instance.PlayStart(letsPlay);
        questionText = GameObject.Find("QuestionText").GetComponent<TMP_Text>();
        soundController.letsPlay();

        aBoxImage.color = new Color32(0, 0, 0, 255);
        bBoxImage.color = new Color32(0, 0, 0, 255);
        cBoxImage.color = new Color32(0, 0, 0, 255);
        dBoxImage.color = new Color32(0, 0, 0, 255);

        // Set the text
        allQuestions = loadQuestions();
        int randomNum = Random.Range(1, 500);
        //soundController.letsPlay();

        for (int i = 0; i < 10; i++)
        {
            tenQuestionArray.Add(allQuestions[randomNum]);
            randomNum = Random.Range(1, 500);
        }

        StartCoroutine(advanceToNextQuestion(3f));
    }

    // Update is called once per frame
    void Update()
    {
    }

    string fixJson(string value)
    {
        value = "{\"Questions\":" + value + "}";
        return value;
    }

    Question[] loadQuestions()
    {
        //SoundManager.Instance.PlayStart();
        // Read the json and load it into a string
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);
        jsonFromFile = File.ReadAllText(filePath);
        //Debug.Log(jsonString);

        // Parse the json into an object
        QuestionList questionList = JsonUtility.FromJson<QuestionList>(jsonFromFile);

        return questionList.questions;
    }

    void generateQuestion()
    {
        // if (soundController != null)
        //{
        //   soundController.letsPlay();
        //}
        if (questionLevel <= 3)
        {
            soundController.playEasyBackgroundMusic();
        }
        if (questionLevel > 3)
        {
            soundController.playHardBackgroundMusic();
        }

        questionText = GameObject.Find("QuestionText").GetComponent<TMP_Text>();
        answerAText = GameObject.Find("AText").GetComponent<TMP_Text>();
        answerBText = GameObject.Find("BText").GetComponent<TMP_Text>();
        answerCText = GameObject.Find("CText").GetComponent<TMP_Text>();
        answerDText = GameObject.Find("DText").GetComponent<TMP_Text>();

        //currentQuestion = tenQuestionArray[questionLevel];
        currentQuestion.question = tenQuestionArray[questionLevel].question;
        currentQuestion.A = tenQuestionArray[questionLevel].A;
        currentQuestion.B = tenQuestionArray[questionLevel].B;
        currentQuestion.C = tenQuestionArray[questionLevel].C;
        currentQuestion.D = tenQuestionArray[questionLevel].D;
        currentQuestion.answer = tenQuestionArray[questionLevel].answer;

        Debug.Log("Correct Answer: " + currentQuestion.answer);

        questionText.text = currentQuestion.question;
        answerAText.text = currentQuestion.A;
        answerBText.text = currentQuestion.B;
        answerCText.text = currentQuestion.C;
        answerDText.text = currentQuestion.D;

    }



    public void checkAnswer(string word)
    {
        currentQuestion = tenQuestionArray[questionLevel];
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


        /* if (word.ToLower() == currentQuestion.answer.ToLower())
        {
            soundController.playRightAnswer();

            switch (word)
            {
                case "a":
                    break;
                case "b":
                    StartCoroutine(flashCorrect(bBoxImage));
                    break;
                case "c":
                    StartCoroutine(flashCorrect(cBoxImage));
                    break;
                case "d":
                    StartCoroutine(flashCorrect(dBoxImage));
                    break;
            }
            //  soundController.playCorrect();
            //SoundManager.Instance.PlayCorrect();

            //   StartCoroutine(AdvanceToNextQuestion());
            questionLevel = questionLevel + 1;
            //StartCoroutine(advanceToNextQuestion(3f));
            StartCoroutine(advanceToNextQuestion(3f));
        }

          else
        {
            // Play the correct sound effect.
            //  soundController.playCorrect();
            //SoundManager.Instance.PlayIncorrect();
            soundController.playWrongAnswer();
            Debug.Log("Incorrect answer");
            sceneManager.LoadMainMenu();
        }
        
         */



    }//checkAnswer

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
            soundController.playRightAnswer();
            questionLevel++;
            StartCoroutine(flashCorrect(imageToFlash));
        }
        if (currentQuestion.answer.ToLower() == word.ToLower())
        {
            soundController.playRightAnswer();
            questionLevel++;
            StartCoroutine(flashCorrect(imageToFlash));
        }
        if (currentQuestion.answer.ToLower() == word.ToLower())
        {
            soundController.playRightAnswer();
            questionLevel++;
            StartCoroutine(flashCorrect(imageToFlash));

        }
        if (currentQuestion.answer.ToLower() == word.ToLower())
        {
            soundController.playRightAnswer();
            questionLevel++;
            StartCoroutine(flashCorrect(imageToFlash));
        }
        else if(currentQuestion.answer.ToLower() != word.ToLower())
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
        StartCoroutine(advanceToNextQuestion(2f));

    }
    IEnumerator flashIncorrect(Image imageToFlash)
    {
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
        sceneManager.LoadMainMenu();
    }


}

