using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTile : MonoBehaviour {

	GameObject tileGenerator;
	GameObject mainGame;

	public float offScreenDistance;

	// Use this for initialization
	void Start () {
		tileGenerator = GameObject.Find("TileGenerator");
		mainGame = GameObject.Find("MainGame");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (transform.position.x > mainGame.transform.position.x + offScreenDistance)
			Destroy();
	}

	void Destroy() {
		tileGenerator.GetComponent<TileGenerator>().RemoveTile();
		Destroy(gameObject);
	}
}
