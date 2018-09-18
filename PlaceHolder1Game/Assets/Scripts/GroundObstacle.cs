using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundObstacle : MonoBehaviour {

	public GameObject MainGame;
	public float ScreenWidth;
	public float minTranslate;
    public float maxTranslate;
    public GameObject Obstacle;
    public GameObject BreakableObstacle;
	public int breakableChance;
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
		if(IsBreakable())
		{
			BreakableObstacle.transform.localPosition = new Vector3(0, 0, 0);
			Obstacle.transform.localPosition = new Vector3(0, 15, 0);
			BreakableObstacle.GetComponent<ChangeSprite>().RandomSprite();
		}
		else
		{
			BreakableObstacle.transform.localPosition = new Vector3(0, 15, 0);
			Obstacle.transform.localPosition = new Vector3(0, 0, 0);
			Obstacle.GetComponent<ChangeSprite>().RandomSprite();
		}
		transform.Translate(- Random.Range(minTranslate, maxTranslate), 0, 0);
		BreakableObstacle.GetComponent<BreakObstacle>().ResetSprite();
	}

	bool IsBreakable()
	{
        return Random.Range(0, 100) <= breakableChance;
	}
}
