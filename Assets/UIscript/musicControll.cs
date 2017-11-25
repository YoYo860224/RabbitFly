using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicControll : MonoBehaviour {

    private AudioSource audioSource;
    private bool muteState;
    private float preVolume;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.5f;
        muteState = false;
        preVolume = audioSource.volume;
    }
	void Update () {
		
	}

    public void VolumeChanged(float newVolume)
    {
        audioSource.volume = newVolume;
        muteState = false;
    }
    public void MuteClick()
    {
        muteState = !muteState;
        if (muteState)
        {
            preVolume = audioSource.volume;
            audioSource.volume = 0;
        }
        else
            audioSource.volume = preVolume;
    }
}
