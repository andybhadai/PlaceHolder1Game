using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowY : MonoBehaviour {

	public GameObject thingToFollow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 tmp = transform.position;
		transform.position = new Vector3(tmp.x, thingToFollow.transform.position.y, tmp.z);
	}
}
