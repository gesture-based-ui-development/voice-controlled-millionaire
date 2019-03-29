using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    // Audio players components.
    public AudioSource _audios;
    public AudioClip[] audioClipArray;
    

    

    // Singleton instance.
    public static SoundManager Instance = null;

    // Initialize the singleton instance.
    private void Awake()
    {
        _audios = GetComponent<AudioSource>();

        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    // Play a single clip through the sound effects source.
    public void PlayStart()
    {
        Debug.Log("[SOUND MANAGER]:playStart()");

        _audios.clip = audioClipArray[0];
        _audios.PlayOneShot(_audios.clip);
    }

    // Play a single clip through the music source.
    public void PlayCorrect()
    {
        Debug.Log("[SOUND MANAGER]:playCorrect()");

        _audios.clip = audioClipArray[1];
        _audios.PlayOneShot(_audios.clip);
    }
    // Play a single clip through the music source.
    public void PlayIncorrect()
    {
        Debug.Log("[SOUND MANAGER]:PlayIncorrect()");

        _audios.clip = audioClipArray[2];
        _audios.PlayOneShot(_audios.clip);
    }

}
