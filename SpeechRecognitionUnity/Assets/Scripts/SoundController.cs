using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    public static AudioSource letsPlayAudio;
    public static AudioSource easyBackgroundMusic;
    public static AudioSource rightAnswerAudio;
    public static AudioSource wrongAnswerAudio;
    public static AudioSource hardBackgroundMusic;

    void Awake()
    {
        Debug.Log("[SOUND CONTROLLER]:start()");
        letsPlayAudio = GameObject.Find("LetsPlay").GetComponent<AudioSource>();
        easyBackgroundMusic = GameObject.Find("easyBackgroundMusic").GetComponent<AudioSource>();
        rightAnswerAudio = GameObject.Find("CorrectAnswer").GetComponent<AudioSource>();
        wrongAnswerAudio = GameObject.Find("WrongAnswer").GetComponent<AudioSource>();
        hardBackgroundMusic = GameObject.Find("hardBackgroundMusic").GetComponent<AudioSource>();
    }
    void Start()
    {

    }

    public void letsPlay()
    {
        Debug.Log("[SOUND CONTROLLER]:letsplay()");
        letsPlayAudio.Play();
    
    }
    public void playEasyBackgroundMusic()
    {
        Debug.Log("[SOUND CONTROLLER]:playCorrect()");
        letsPlayAudio.Play();
    }
    public void playHardBackgroundMusic()
    {
        Debug.Log("[SOUND CONTROLLER]:playCorrect()");
        letsPlayAudio.Play();
    }
    public void playRightAnswer()
    {
        Debug.Log("[SOUND CONTROLLER]:playCorrect()");
        letsPlayAudio.Play();
    }
    public void playWrongAnswer()
    {
        Debug.Log("[SOUND CONTROLLER]:playCorrect()");
        letsPlayAudio.Play();
    }

}
