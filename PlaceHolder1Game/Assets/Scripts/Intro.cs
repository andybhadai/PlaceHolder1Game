using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour {

	public Sprite []sprites;
	private int counter;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt("FinishedIntro", 0) == 0){
			SetSprite();
		}
		else
		{
			LeaveIntro();
		}
	}
	
	// Update is called once per frame
	void Update () {
		CheckClick();
	}

	void SetSprite()
	{
		this.GetComponent<SpriteRenderer>().sprite = sprites[counter];
	}

	public void NextSprite()
	{
		if(counter < sprites.Length-1)
		{
			counter++;
			SetSprite();
		}
		else
		{
			LeaveIntro();
		}
	}

	private void CheckClick()
    {
        if (Input.touchCount == 1)
        {
			Touch touch = Input.GetTouch(0);
			if(touch.phase == TouchPhase.Ended)
			{
				NextSprite();
			}
		}
	}

	void LeaveIntro()
	{
		PlayerPrefs.SetInt("FinishedIntro", 1);
		SceneManager.LoadScene("StartMenu");
	}
}
