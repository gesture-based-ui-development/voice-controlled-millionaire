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

	private string gameDataFileName = "questions.json";
	private string jsonString;
	private string jsonFromFile;
	public TMP_Text questionText;
	public TMP_Text answerAText;
	public TMP_Text answerBText;
	public TMP_Text answerCText;
	public TMP_Text answerDText;

	// Use this for initialization
	void Start () 
	{
		// Set the text
		generateText();
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

	Question generateQuestion()
	{
		// Read the json and load it into a string
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);
		jsonFromFile = File.ReadAllText(filePath);
		//Debug.Log(jsonString);

		// Parse the json into an object
		QuestionList questionList = JsonUtility.FromJson<QuestionList>(jsonFromFile);

		int randomNum = Random.Range(1, 500);

		return questionList.questions[randomNum];
	} 

	void generateText()
	{
		Question newQuestion = generateQuestion();
		questionText.text = newQuestion.question;
		answerAText.text = newQuestion.A;
		answerBText.text = newQuestion.B;
		answerCText.text = newQuestion.C;
		answerDText.text = newQuestion.D;
	}
	
}

