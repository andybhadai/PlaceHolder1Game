using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PauseGame()
	{
		Time.timeScale = 0;
		this.gameObject.SetActive(true);
	}

	public void UnPauseGame()
	{
		Time.timeScale = 1;
		this.gameObject.SetActive(false);
	}

	public void QuitGame()
	{
		UnPauseGame();
		SceneManager.LoadScene(0);
	}
}
