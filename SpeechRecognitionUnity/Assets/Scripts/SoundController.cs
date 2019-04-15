using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
SoundController is used to control all the sound effects the game uses aswell as music for backround etc.
 */
public class SoundController : MonoBehaviour
{

    public static AudioSource letsPlayAudio;
    public static AudioSource easyBackgroundMusic;
    public static AudioSource rightAnswerAudio;
    public static AudioSource wrongAnswerAudio;
    public static AudioSource hardBackgroundMusic;

    public static AudioSource sound_32000;
    public static AudioSource sound_64000;
    public static AudioSource sound_250000;
    public static AudioSource sound_500000;

    public static AudioSource sound_final;
    void Awake()
    {
        letsPlayAudio = GameObject.Find("LetsPlay").GetComponent<AudioSource>();

        rightAnswerAudio = GameObject.Find("CorrectAnswer").GetComponent<AudioSource>();
        wrongAnswerAudio = GameObject.Find("WrongAnswer").GetComponent<AudioSource>();

        // Background sounds for different level questions.
        easyBackgroundMusic = GameObject.Find("easyBackgroundMusic").GetComponent<AudioSource>();
        sound_32000 = GameObject.Find("32000_sound").GetComponent<AudioSource>();
        sound_64000 = GameObject.Find("64000_sound").GetComponent<AudioSource>();
        sound_250000 = GameObject.Find("250000_sound").GetComponent<AudioSource>();
        sound_500000 = GameObject.Find("500000_sound").GetComponent<AudioSource>();
        hardBackgroundMusic = GameObject.Find("hardBackgroundMusic").GetComponent<AudioSource>();

        // Sound effects for final answer
        sound_final = GameObject.Find("finalAnswer_sound").GetComponent<AudioSource>();
    }

    void Start()
    {

    }

    public void letsPlay()
    {
        letsPlayAudio.Play();
    }

    public void playRightAnswer()
    {
        sound_final.Stop();

        rightAnswerAudio.Play();
    }
    public void playWrongAnswer()
    {
        sound_final.Stop();

        wrongAnswerAudio.Play();
    }
    // =================================== Background sounds for different level questions. 

    /**
     * Sound effect for level 1-5.
     */
    public void playEasyBackgroundMusic()
    {
        easyBackgroundMusic.Play();
    }

    /**
     * Sound effect for level 6-10.
     */
    public void Play32000Sound()
    {
        easyBackgroundMusic.Stop();
        sound_32000.Play();
    }

    /**
    * Sound effect for level 11.
    */
    public void Play64000Sound()
    {
        sound_32000.Stop();
        sound_64000.Play();
    }

    /**
    * Sound effect for level 12-13.
    */
    public void Play250000Sound()
    {
        sound_64000.Stop();

        sound_250000.Play();
    }

    /**
    * Sound effect for level 14.
    */
    public void Play500000Sound()
    {
        sound_64000.Stop();
        sound_500000.Play();
    }

    /**
    * Sound effect for level 15.
    */
    public void playHardBackgroundMusic()
    {
        sound_500000.Stop();
        hardBackgroundMusic.Play();
    }

    /**
    * Sound effect for final answer.
    * Will play in loop until answer chosen.
    */
    public void playFinalSound()
    {
        easyBackgroundMusic.Stop();
        // sound_500000.Stop();
        sound_final.Play();
    }
    public void stopFinalSound()
    {
        sound_final.Stop();

    }
}
