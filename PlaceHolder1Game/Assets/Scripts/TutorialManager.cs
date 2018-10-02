using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        else if (x < -150 && x >= -180)
        {
            tutorialText.SetText("Jump through rings to dash");
        }
        else if (x < -180 && x >= -200)
        {
            tutorialText.SetText("Dash through birds to kill them");
        }
        else if (x < -200 && x >= -220)
        {
            tutorialText.SetText("TUTORIAL COMPLETED!");
        }
        else if (x < -240)
        {
            SceneManager.LoadScene(0);
        }
    }
}
