using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;

public class Settings : MonoBehaviour {

	public Slider Slider;

	// Use this for initialization
	void Start () {
		this.Slider.value = PlayerPrefs.GetFloat("soundLevel", 0f);
	}

	public void SetSoundLevel(){
		PlayerPrefs.SetFloat("soundLevel", this.Slider.value);
	}
}
