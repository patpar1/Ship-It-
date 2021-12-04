using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{    
    public AudioSource engineAudioSource;
    public AudioSource windAudioSource;
    public AudioSource winAudio;
    public AudioSource loseAudio;

    public bool isWindPlaying;

    public float minPitch = 0.3f;
    public float maxPitch = 0.6f;
    public float pitchSpeed = 0.01f;

    private float CurrentPitch = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        isWindPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        if (forwardInput > 0 && CurrentPitch < maxPitch)
        {
            CurrentPitch += forwardInput * pitchSpeed;
        }
        else if (CurrentPitch > minPitch)
        {
            CurrentPitch -= pitchSpeed;
        }

        engineAudioSource.pitch = CurrentPitch;
    }

    public void ToggleWindAudio()
    {
        if (!isWindPlaying)
        {
            windAudioSource.Play();
            isWindPlaying = true;
        }
        else 
        {
            windAudioSource.Stop();
            isWindPlaying = false;
        }
    }

    public void PlayWinAudio()
    {
        winAudio.Play();
    }

    public void PlayLoseAudio()
    {
        loseAudio.Play();
    }
}
