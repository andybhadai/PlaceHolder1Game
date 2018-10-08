using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadIntro : MonoBehaviour {

	public bool resetIntro;

	// Use this for initialization
	void Start () {
		if(resetIntro)
		{
			PlayerPrefs.SetInt("FinishedIntro", 0);
		}
		
		if (PlayerPrefs.GetInt("FinishedIntro", 0) == 0){
			SceneManager.LoadScene("Intro");
		}
	}
}
