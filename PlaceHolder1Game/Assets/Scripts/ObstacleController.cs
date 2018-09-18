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
    public GameObject breakableObstacle;
    public int breakableChance;
    public GameObject mainGame;


    void Start()
    {
        SpawnObstacle();
        SpawnAirObstacle();
    }

    public void SpawnObstacle()
    {
        // obstacle.transform.position = new Vector3(xPos, yPos, 0);
    }

    public void SpawnAirObstacle()
    {
        // airObstacle.transform.position = new Vector3(xPosAir, yPosAir, 0);
    }

    public void SpawnBreakableObstacle()
    {
        // breakableObstacle.transform.position = new Vector3(xPos, yPos, 0);
    }

    public bool Breakable()
    {   
        Debug.Log("test");
        return Random.Range(0, 100) <= breakableChance;
    }

    public void MoveObstacle(float min, float max)
    {
        obstacle.transform.position = new Vector3(mainGame.transform.position.x - Random.Range(min, max), obstacle.transform.position.y, obstacle.transform.position.z);
        // transform.Translate(- Random.Range(this.minimumPosition, this.maximumPosition), 0, 0);
    }

    public void MoveAirObstacle(float min, float max)
    {
        Debug.Log("Old: "+ airObstacle.transform.position);
        airObstacle.transform.position = new Vector3(mainGame.transform.position.x - Random.Range(min, max), airObstacle.transform.position.y, airObstacle.transform.position.z);
        Debug.Log("New: "+ airObstacle.transform.position);
    }

    public void MoveBreakableObstacle(float min, float max)
    {
        breakableObstacle.transform.position = new Vector3(mainGame.transform.position.x - Random.Range(min, max), breakableObstacle.transform.position.y, breakableObstacle.transform.position.z);
    }
}
