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

    public SceneManagement sceneManager = new SceneManagement();
    public SoundController soundController = new SoundController();
    public static Question currentQuestion = new Question();
    static List<Question> tenQuestionArray = new List<Question>();
    public Question[] allQuestions;
    private string gameDataFileName = "questions.json";
    private string jsonString;
    private string jsonFromFile;
    TMP_Text questionText;
    public TMP_Text answerAText;
    public TMP_Text answerBText;
    public TMP_Text answerCText;
    public TMP_Text answerDText;
    public static int questionLevel = 0;

    // Use this for initialization
    void Start()
    {
        questionText = GameObject.Find("QuestionText").GetComponent<TMP_Text>();

        // Set the text
        allQuestions = loadQuestions();
        int randomNum = Random.Range(1, 500);

        for (int i = 0; i < 10; i++)
        {
            tenQuestionArray.Add(allQuestions[randomNum]);
			randomNum = Random.Range(1, 500);
        }

        generateQuestion();
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
        if (soundController != null)
        {
            soundController.letsPlay();
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
        Debug.Log("Question: " + currentQuestion.question);
        
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
        Debug.Log("Correct Answer: " + currentQuestion.answer);

        if (word.ToLower() == currentQuestion.answer.ToLower())
        {
            Debug.Log("Answer correct.");
            questionLevel = questionLevel + 1;
            generateQuestion();
        }
        else
        {
            Debug.Log("Incorrect answer");
            sceneManager.ExitGame();
        }
    }

}

