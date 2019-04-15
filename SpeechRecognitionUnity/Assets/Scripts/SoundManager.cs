using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
SoundManager is the initial class used to control sound.
 */
public class SoundManager : MonoBehaviour
{

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
    public void PlayMenu()
    {
        Debug.Log("[SOUND MANAGER]:playStart()");

        _audios.clip = audioClipArray[0];
        //   _audios.PlayOneShot(_audios.clip);
        _audios.Play();
    }
    public void StopMenuMusic()
    {
        Debug.Log("[SOUND MANAGER]:STOP()");

        _audios.Stop();
    }


}
