using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPosition : MonoBehaviour {

	public GameObject mainGame;

	// Use this for initialization
	void Start () {
		//mainGame = GameObject.Find("MainGame");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}

	void OnBecameInvisible() {
		addNewObject();
    	Destroy(gameObject);
    }

	
	void addNewObject() {
		GameObject instance = Instantiate(Resources.Load("Red", typeof(GameObject)), new Vector3(mainGame.transform.position.x + 18.5F, 0, 0), transform.rotation) as GameObject;
		instance.transform.parent = GameObject.Find("Scrolling").transform;
	}
}
