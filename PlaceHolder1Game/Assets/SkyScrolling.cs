using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyScrolling : MonoBehaviour {

	float distance;
	public float speed;
	

	// Use this for initialization
	void Start () {
		distance = GetComponent<RectTransform>().rect.width - 0.1f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate (Vector2.left * speed * Time.deltaTime);
	}

	void OnBecameInvisible() {
    	transform.Translate(-distance,0,0);
    }
}
