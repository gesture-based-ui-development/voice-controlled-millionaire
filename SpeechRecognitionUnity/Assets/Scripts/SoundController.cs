using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

	public static AudioSource letsPlayAudio;
    public static AudioSource correctAudioSound;

    void Start()

	{
        Debug.Log("[SOUND CONTROLLER]:start()");

      //  correctAudioSound = GameObject.Find("correctAudio").GetComponent<AudioSource>();
    }

    public void letsPlay()
	{
        Debug.Log("[SOUND CONTROLLER]:letsplay()");
		letsPlayAudio.Play();
	}
    public void playCorrect()
    {
        Debug.Log("[SOUND CONTROLLER]:playCorrect()");
        correctAudioSound.Play();
    }
}
