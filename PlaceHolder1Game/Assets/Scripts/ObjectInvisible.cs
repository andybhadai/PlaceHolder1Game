using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInvisible : MonoBehaviour {

    public int minimumPosition;
    public int maximumPosition;
    public List<Sprite> sprites;
    public bool isBreakable;
    public bool isAirObstacle;
    public GameObject objects;
    public GameObject mainGame;


    void Start()
    {
        RandomSprite();
    }

    void RandomSprite()
    {
    	this.GetComponent<SpriteRenderer>().sprite = sprites[Mathf.FloorToInt(Random.Range(0, sprites.Count))];
    }

    void OnBecameInvisible() {
        if(isAirObstacle)
        {
            Debug.Log("Bird");
            objects.GetComponent<ObstacleController>().MoveAirObstacle(minimumPosition, maximumPosition);
        } 
        else if(isBreakable)
        {
            objects.GetComponent<ObstacleController>().SpawnObstacle();
            objects.GetComponent<ObstacleController>().MoveObstacle(minimumPosition, maximumPosition);
        }
        else if (objects.GetComponent<ObstacleController>().Breakable())
        {
            Debug.Log("Break?");
            objects.GetComponent<ObstacleController>().SpawnBreakableObstacle();
            objects.GetComponent<ObstacleController>().MoveBreakableObstacle(minimumPosition, maximumPosition);
        }
        else
        {
            objects.GetComponent<ObstacleController>().MoveObstacle(minimumPosition, maximumPosition);
        }
        
        RandomSprite();
    }

    public void Delete()
    {
        GameObject.Destroy(this);
    }
}
