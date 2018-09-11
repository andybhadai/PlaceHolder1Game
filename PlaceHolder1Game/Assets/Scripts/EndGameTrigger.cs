using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameTrigger : MonoBehaviour {

	// Update is called once per frame
	void FixedUpdate () {
		
	}

	void OnBecameInvisible() {
        this.SaveScoreLocally();
        SceneManager.LoadSceneAsync("GameOver");
	}

    private void SaveScoreLocally()
    {
        PlayerPrefs.SetFloat("score", this.transform.position.x);
        PlayerPrefs.Save();
    }
}
