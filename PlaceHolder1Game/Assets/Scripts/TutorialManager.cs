using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour {

    public TextMeshProUGUI tutorialText;
    public GameObject mainGame;
	
	// Update is called once per frame
	void FixedUpdate () {
        float x = mainGame.transform.position.x;
        float y = mainGame.transform.position.y;

        Debug.Log($"X: {x}, Y: {y}");

        if(x < -30 && x >= -40)
        {
            tutorialText.SetText("Swipe left to dash");
        }else if(x < -50 && x >= -80)
        {
            tutorialText.SetText("Tap three times to break big rocks!");
        }
    }
}
