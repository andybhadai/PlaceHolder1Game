using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverSceneManager : MonoBehaviour {

    public Text GameOverText;
    public Text GameOverCoinsText;

	// Use this for initialization
	void Start () {
        int score = (int) PlayerPrefs.GetFloat("score", 0f);
        GameOverText.text = $"{score * -1} M";

        int coins = (int) PlayerPrefs.GetInt("amountOfCoins", 0);
        GameOverCoinsText.text = $"{coins}";

        // Highscore will be saved to server when player is game over
        this.GetComponent<Highscore>().AddHighscore();
	}
}
