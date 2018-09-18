using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour {

	public List<Sprite> sprites;


    void Start()
    {
        RandomSprite();
    }

    public void RandomSprite()
    {
    	GetComponent<SpriteRenderer>().sprite = sprites[Mathf.FloorToInt(Random.Range(0, sprites.Count))];
    }
}
