using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

    public GameObject WoodenFence;
    
    void Start()
    {
        this.SpawnWoodenFence();
    }

    public void SpawnWoodenFence()
    {
        this.WoodenFence.transform.position = new Vector3 { x = -10, y = -4 };
        Instantiate(this.WoodenFence);
    }


}
