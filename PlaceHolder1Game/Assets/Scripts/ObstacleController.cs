using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

    public GameObject WoodenFence;        
    public float xPos;
    public float yPos;

    void Start()
    {
        this.SpawnWoodenFence();
    }

    public void SpawnWoodenFence()
    {
        this.WoodenFence.transform.position = new Vector3(xPos, yPos, 0);
        Instantiate(this.WoodenFence);
    }


}
