using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

	public static AudioSource letsPlayAudio;

	void Start()
	{
	}

	public void letsPlay()
	{
		letsPlayAudio.Play();
	}
}
