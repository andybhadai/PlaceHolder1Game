using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInvisible : MonoBehaviour {

    public int minimumPosition;
    public int maximumPosition;
    public int breakableChance;

    public List<Sprite> sprites;
    private ObstacleController script;

    void Start()
    {
        script = GetComponent<ObstacleController>();
    }

    void OnBecameInvisible() {
        int random = Random.Range(0, 100);

        if(random <= breakableChance)
        {
            //this.GetComponent<SpriteRenderer>().sprite = 
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = sprites[Mathf.FloorToInt(Random.Range(0, sprites.Count))];
            transform.Translate(-Random.Range(this.minimumPosition, this.maximumPosition), 0, 0);
        }
    }
}
