using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakObstacle : MonoBehaviour
{

    public List<Sprite> sprites;
	public int spriteState = 0;
	
    public List<GameObject> spawnables;

	public float spawnNothing;
	public float spawnCoin;
	public float spawnDroplet;
	public float spawnJerrycan;
	public float spawnObstacle;
	
	

    void Start()
    {
		ResetSprite();
    }

    void OnMouseDown()
    {
		if(spriteState < sprites.Count -1)
		{
			spriteState++;
			GetComponent<SpriteRenderer>().sprite = sprites[spriteState];
		}
		
		if(spriteState == sprites.Count -1)
		{
			ChangeCollider(false);
			WhatToSpawn();
		}
    }

	public void ResetSprite() 
	{
		spriteState = 0;
		ChangeCollider(true);
		GetComponent<SpriteRenderer>().sprite = sprites[spriteState];
	}

	void ChangeCollider(bool on)
	{
		GetComponent<BoxCollider2D>().enabled = on;
	}

	void WhatToSpawn()
	{
		float rdm = Random.Range(0, 100);
		if(rdm <= spawnNothing)
		{
			
		}
		else if(rdm <= spawnCoin)
		{
			Spawn(spawnables[1]);
		}
		else if(rdm <= spawnDroplet)
		{
			Spawn(spawnables[2]);
		}
		else if(rdm <= spawnJerrycan)
		{
			Spawn(spawnables[3]);
		}
		else if(rdm <= spawnObstacle)
		{
			Spawn(spawnables[4]);
		}
	}

	void Spawn(GameObject thingToSpawn)
	{
		GameObject Spawned = Instantiate(thingToSpawn, transform.position, Quaternion.identity) as GameObject;
		Spawned.transform.parent = transform;
	}
}
