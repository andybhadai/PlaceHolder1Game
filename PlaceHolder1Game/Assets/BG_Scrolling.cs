using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Scrolling : MonoBehaviour {

	public float scrollSpeed;
	Vector2 startPosition;
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, 20);
		transform.position = startPosition + Vector2.right * newPosition;
	}
}
