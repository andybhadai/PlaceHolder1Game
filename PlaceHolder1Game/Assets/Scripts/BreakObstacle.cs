using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakObstacle : MonoBehaviour
{

    public List<Sprite> sprites;
	private int spriteState = 0;

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
			Debug.Log("TEST ");
		}
		Debug.Log(spriteState);
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
}
