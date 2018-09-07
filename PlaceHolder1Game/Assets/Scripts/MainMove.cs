using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMove : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		speed = speed + 0.005f;
		transform.Translate (Vector2.left * speed * Time.deltaTime);
	}
}
