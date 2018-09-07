using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMove : MonoBehaviour {

	public float speed;
	public float speedOverTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		speed = speed + speedOverTime;
		transform.Translate (Vector2.left * speed * Time.deltaTime);
	}
}
