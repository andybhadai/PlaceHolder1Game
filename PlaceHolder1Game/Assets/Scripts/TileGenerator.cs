using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour {

    public GameObject[] GameObjects;
    private int iterations = 0;
    public GameObject mainGame;
    public int obstacleChance;
    public int ringObstacleChance;
    private int generatedTiles;
    public int startTilesAmount;
    public int tileWidth;

    private int lastTile;


    void Start() 
    {
        for(int i = 0; i < startTilesAmount; i++)
        {
            NewTile();
        }
    }

    void Update()
    {

    }

    private int RandomNumber()
    {
        int rdm = Random.Range(0, GameObjects.Length);
        while(rdm == lastTile)
        {
            rdm = Random.Range(0, GameObjects.Length);
        }
        lastTile = rdm;
        return rdm;
    }

    public void RemoveTile() 
    {
        generatedTiles = generatedTiles - 2;
        NewTile();
        generatedTiles++;
    }

    public void NewTile()
    {
        generatedTiles++;
        Spawn(RandomNumber());
    }

    private void Spawn(int obstacle)
    {
        int x = -tileWidth * generatedTiles;
        Instantiate(GameObjects[obstacle], new Vector3(mainGame.transform.position.x + x, 0, 0), Quaternion.identity);
    }
}
