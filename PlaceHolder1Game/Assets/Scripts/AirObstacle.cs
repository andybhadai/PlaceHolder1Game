using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirObstacle : MonoBehaviour {

	public GameObject MainGame;
	public float ScreenWidth;
	public float minTranslate;
    public float maxTranslate;
    public GameObject Obstacle;
	public float startPosX;

	// Use this for initialization
	void Start () {
		transform.position = new Vector2(startPosX, transform.position.y);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(transform.position.x > MainGame.transform.position.x + ScreenWidth)
			ObjectInvisible();
	}

	void ObjectInvisible()
	{
		Obstacle.GetComponent<ChangeSprite>().RandomSprite();
		transform.Translate(- Random.Range(minTranslate, maxTranslate), 0, 0);
	}
}
