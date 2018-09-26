using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour {

    public GameObject[] GameObjects;
    private int iterations = 0;
    public GameObject mainGame;
    public int chance;
    private int generatedTiles;
    public int startTilesAmount;


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
        return Random.Range(1, GameObjects.Length);
    }

    public void RemoveTile() 
    {
        generatedTiles--;
        NewTile();
    }

    public void NewTile()
    {
        generatedTiles++;

        int random = Random.Range(0, 100);

        if(random < chance)
        {
            Spawn(RandomNumber());
        }
        else
        {
            Spawn(0);
        }
    }

    private void Spawn(int obstacle)
    {
        int x = -15 * generatedTiles;
        Instantiate(GameObjects[obstacle], new Vector3(mainGame.transform.position.x + x, 0, 0), Quaternion.identity);
    }
}
