using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameTrigger : MonoBehaviour {

	// Update is called once per frame
	void FixedUpdate () {
		
	}

	void OnBecameInvisible() {
		Debug.Log("END GAME");
		SceneManager.LoadScene("GameOver");
	}
}
