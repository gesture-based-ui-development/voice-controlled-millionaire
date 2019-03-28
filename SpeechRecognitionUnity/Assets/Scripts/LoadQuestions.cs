using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

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
public class LoadQuestions : MonoBehaviour {

	SceneManagement sceneManager = new SceneManagement();
	SoundController soundController = new SoundController();
	Question currentQuestion = new Question();
	List<Question> tenQuestionArray = new List<Question>();
	public Question[] allQuestions;
	private string gameDataFileName = "questions.json";
	private string jsonString;
	private string jsonFromFile;
	public TMP_Text questionText;
	public TMP_Text answerAText;
	public TMP_Text answerBText;
	public TMP_Text answerCText;
	public TMP_Text answerDText;
	public int questionLevel=0;

	// Use this for initialization
	void Start () 
	{
		// Set the text
		allQuestions = loadQuestions();
		int randomNum = Random.Range(1, 500);

		for(int i=0; i<10; i++)
		{
			tenQuestionArray.Add(allQuestions[randomNum]);
		}

		currentQuestion = generateQuestion();
	}
	
	// Update is called once per frame
	void Update () 
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

	Question generateQuestion()
	{
		if(soundController!=null)
		{
			soundController.letsPlay();
		}
		
		currentQuestion = tenQuestionArray[questionLevel];
		questionText.text = currentQuestion.question;
		answerAText.text = currentQuestion.A;
		answerBText.text = currentQuestion.B;
		answerCText.text = currentQuestion.C;
		answerDText.text = currentQuestion.D;
		Debug.Log("Current Answer: " + currentQuestion.answer);
		Debug.Log("Current Level: " + questionLevel);

		return currentQuestion;
	}

	public void checkAnswer(string word)
	{
		currentQuestion = tenQuestionArray[questionLevel];
		Debug.Log("Your Word: " + word);
		Debug.Log("Correct Answer: " + currentQuestion.answer);
		if(word==currentQuestion.answer)
		{
			Debug.Log("Answer correct.");
			questionLevel++;
			currentQuestion = generateQuestion();
		}
		else
		{
			Debug.Log("Incorrect answer");
			sceneManager.ReturnToMenu();
		}
	}
	
}

