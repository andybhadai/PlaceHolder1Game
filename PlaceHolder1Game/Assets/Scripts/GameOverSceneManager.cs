using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverSceneManager : MonoBehaviour {

    public TextMeshProUGUI GameOverText;

	// Use this for initialization
	void Start () {
        int score = (int) PlayerPrefs.GetFloat("score", 0f);
        this.GameOverText.text = $"{score * -1} M";

        // Highscore will be saved to server when player is game over
        this.GetComponent<Highscore>().AddHighscore();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
