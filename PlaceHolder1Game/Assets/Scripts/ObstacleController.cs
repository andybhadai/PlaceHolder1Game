using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

    public GameObject obstacle;        
    public float xPos;
    public float yPos;
    public GameObject airObstacle;
    public float xPosAir;
    public float yPosAir;

    void Start()
    {
        SpawnObstacle();
        SpawnAirObstacle();
    }

    public void SpawnObstacle()
    {
        obstacle.transform.position = new Vector3(xPos, yPos, 0);
        Instantiate(obstacle);
    }

    public void SpawnAirObstacle()
    {
        airObstacle.transform.position = new Vector3(xPosAir, yPosAir, 0);
        Instantiate(airObstacle);
    }
}
