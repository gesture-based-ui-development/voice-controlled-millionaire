using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventHandler : MonoBehaviour
{
    // Variables
    LoadQuestions loadQuestionsClass = new LoadQuestions();

    // Image variables
    public Image aBoxImage;
    public Image bBoxImage;
    public Image cBoxImage;
    public Image dBoxImage;

    // Start is called before the first frame update
    void Start()
    {
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
        loadQuestionsClass.helperFunction(aBoxImage, "a");
    }
    public void selectB()
    {
        loadQuestionsClass.helperFunction(bBoxImage, "b");
    }
    public void selectC()
    {
        loadQuestionsClass.helperFunction(cBoxImage, "c");

    }
    public void selectD()
    {
        loadQuestionsClass.helperFunction(dBoxImage, "d");   
    }
}
