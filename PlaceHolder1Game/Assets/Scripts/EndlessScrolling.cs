using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessScrolling : MonoBehaviour {

	public Transform reference;
	
	// Use this for initialization
	void Start () {
		for(int i=0; i < 2; i++){
			GameObject instance = Instantiate(Resources.Load("Normal", typeof(GameObject)), new Vector3(i * 18.0F, 0, 0), transform.rotation) as GameObject;
			instance.transform.parent = GameObject.Find("Scrolling").transform;
		}
	}
}
