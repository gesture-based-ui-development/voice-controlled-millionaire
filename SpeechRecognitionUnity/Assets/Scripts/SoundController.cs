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
        letsPlayAudio.Play();
    }
    public void playEasyBackgroundMusic()
    {
        easyBackgroundMusic.Play();
    }
    public void playHardBackgroundMusic()
    {
        easyBackgroundMusic.Stop();
        hardBackgroundMusic.Play();
    }
    public void playRightAnswer()
    {
        rightAnswerAudio.Play();
    }
    public void playWrongAnswer()
    {
        wrongAnswerAudio.Play();
    }

}
