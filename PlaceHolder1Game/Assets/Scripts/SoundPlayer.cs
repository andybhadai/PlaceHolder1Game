using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {

	public AudioSource AudioData;

	// Use this for initialization
	void Start () {
		this.AudioData = GetComponent<AudioSource>();
		this.AudioData.loop = true;
		this.AudioData.Play(0);
	}
}
