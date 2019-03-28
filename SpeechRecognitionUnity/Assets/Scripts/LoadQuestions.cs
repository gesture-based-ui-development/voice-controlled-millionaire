using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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
	
	// Use this for initialization
	void Start () 
	{
		Debug.Log(questionList);
		Debug.Log(questionList.questions[0].question);
		Debug.Log(questionList.questions[0].A);
		Debug.Log(questionList.questions[0].B);
		Debug.Log(questionList.questions[0].C);
		Debug.Log(questionList.questions[0].D);
		Debug.Log(questionList.questions[0].answer);
		//Debug.Log(newQuestion[2].B);
		//Debug.Log(newQuestion[2].C);
		//Debug.Log(newQuestion[2].D);
		//Debug.Log(newQuestion[2].answer);
		//Debug.Log(jsonString);
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

	void generateQuestion()
	{
		// Read the json and load it into a string
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);
		jsonFromFile = File.ReadAllText(filePath);
		//Debug.Log(jsonString);

		// Parse the json into an object
		QuestionList questionList = JsonUtility.FromJson<QuestionList>(jsonFromFile);
	} 
}

