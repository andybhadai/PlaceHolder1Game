using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyScrolling : MonoBehaviour {

	float distance;
	

	// Use this for initialization
	void Start () {
		distance = GetComponent<RectTransform>().rect.width - 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnBecameInvisible() {
    	transform.Translate(-distance,0,0);
    }
}
