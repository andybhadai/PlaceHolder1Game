using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject Player;
    private Vector3 Offset;

	// Use this for initialization
	void Start () {
		//this.Offset = transform.position - this.Player.transform.position;
		//transform.position = new Vector3(this.Player.transform.position.x + this.Offset.x, 0, -1);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		//transform.position = this.Player.transform.position + this.Offset;
		transform.position = new Vector3(this.Player.transform.position.x + this.Offset.x, 0, -1);
	}
}
