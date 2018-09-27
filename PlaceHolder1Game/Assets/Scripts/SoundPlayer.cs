using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {

	public AudioSource AudioData;

	// Use this for initialization
	void Start () {

        if (!PlayerPrefs.HasKey("soundOn") || Convert.ToBoolean(PlayerPrefs.GetInt("soundOn"))) PlayMusic();
	}

    void PlayMusic()
    {
        this.AudioData = GetComponent<AudioSource>();
        this.AudioData.loop = true;
        this.AudioData.Play(0);
    }
}
