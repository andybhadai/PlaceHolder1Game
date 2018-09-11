using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameTrigger : MonoBehaviour {

	public GameObject mainGame;

	public float distanceToDeath;

	// Update is called once per frame
	void FixedUpdate () {
		if (transform.position.x - mainGame.transform.position.x > distanceToDeath) {
			SceneManager.LoadScene("GameOver");
		}
	}
}
