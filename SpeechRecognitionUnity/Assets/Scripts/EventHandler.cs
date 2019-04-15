using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
EventHandler is used as an extra to function alongside the speechRecognition. 
This allows buttons to be used in the UI to select answers. 
 */
public class EventHandler : MonoBehaviour
{
    // Variables
    LoadQuestions loadQuestionsClass;

    // Image variables
    public Image aBoxImage;
    public Image bBoxImage;
    public Image cBoxImage;
    public Image dBoxImage;

    // Start is called before the first frame update
    void Start()
    {
        loadQuestionsClass = gameObject.AddComponent(typeof(LoadQuestions)) as LoadQuestions;

        // Image variables
        aBoxImage = GameObject.Find("A").GetComponent<Image>();
        bBoxImage = GameObject.Find("B").GetComponent<Image>();
        cBoxImage = GameObject.Find("C").GetComponent<Image>();
        dBoxImage = GameObject.Find("D").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void selectA()
    {
        // Selects option A from the imagebox. 
        loadQuestionsClass.helperFunction(aBoxImage, "a");
    }

    public void selectB()
    {
        // Selects option B from the imagebox. 
        loadQuestionsClass.helperFunction(bBoxImage, "b");
    }

    public void selectC()
    {
        // Selects option C from the imagebox. 
        loadQuestionsClass.helperFunction(cBoxImage, "c");

    }

    public void selectD()
    {
        // Selects option D from the imagebox. 
        loadQuestionsClass.helperFunction(dBoxImage, "d");
    }

    public void setFinalAnswerTrue()
    {
        // Selects Yes from the finalAnswerBox and sets the answerIsFinal variable to true. 
        SpeechRecognitionEngine.answerIsFinal = true;
    }

    public void setFinalAnswerFalse()
    {
        // Selects No from the finalAnswerBox and sets the answerIsFinal variable to false. 
        SpeechRecognitionEngine.answerIsFinal = false;
    }
}
