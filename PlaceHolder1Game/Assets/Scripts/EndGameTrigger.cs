using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameTrigger : MonoBehaviour {

	public GameObject mainGame;
	
	public void GameOver()
	{
		SaveScoreLocally();
		SceneManager.LoadScene("GameOver");
	}

    private void SaveScoreLocally()
    {
        PlayerPrefs.SetFloat("score", mainGame.transform.position.x);
        PlayerPrefs.Save();
    }

    public void SaveCoins(int coins)
    {
        Debug.Log(coins);
        PlayerPrefs.SetInt("amountOfCoins", coins);
        PlayerPrefs.Save();
    }
}
