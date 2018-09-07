using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInvisible : MonoBehaviour {

    public int minimumPosition;
    public int maximumPosition;
    public List<Sprite> sprites;

    void OnBecameInvisible() {
        this.GetComponent<SpriteRenderer>().sprite = sprites[Mathf.FloorToInt(Random.Range(0, sprites.Count))];
        transform.Translate(- Random.Range(this.minimumPosition, this.maximumPosition), 0, 0);
    }
}
