using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particles : MonoBehaviour {

	public GameObject ParticleObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BeginParticles()
	{
		ParticleObject.GetComponent<ParticleSystem>().Play();
	}
}
