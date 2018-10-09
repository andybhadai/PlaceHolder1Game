using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAnimation : MonoBehaviour {

	int selectedCharacter;

	// Use this for initialization
	void Start () {
		RuntimeAnimatorController newController;
		selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
		// GetComponent<Animator>().runtimeAnimatorController = animations[selectedCharacter] as UnityEditor.Animations.AnimatorController;

		Debug.Log(selectedCharacter);
		switch(selectedCharacter)
		{
			case 0:
				newController = (RuntimeAnimatorController)Resources.Load("Animations/Animation");
				break;
			case 1:
				newController =  (RuntimeAnimatorController)Resources.Load("Animations/NailsAnimation");
				break;
			case 2:
				newController =  (RuntimeAnimatorController)Resources.Load("Animations/LeatherAnimation");
				break;
			default:
            	newController = (RuntimeAnimatorController)Resources.Load("Animations/Animation");
            	break;
		}
		GetComponent<Animator>().runtimeAnimatorController = newController;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
