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

        if(x < -40 && x >= -80)
        {
            tutorialText.SetText("Tap three times to break big rocks!");
        }else if(x < -80 && x >= -100)
        {
            tutorialText.SetText("Dash into houses.");
        }
        else if (x < -110 && x >= -150)
        {
            tutorialText.SetText("Fill your fuel level with drops of oil or jerrycans");
        }
    }
}
