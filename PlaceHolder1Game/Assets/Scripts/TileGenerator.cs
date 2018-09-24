using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour {

    public GameObject[] GameObjects;
    private int iterations = 0;
    public GameObject mainGame;
    public int chance;
    private int generatedTiles;

    private int RandomNumber()
    {
        return Random.Range(1, GameObjects.Length);
    }

    void Update()
    {
        if(iterations == 50)
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

            iterations = 0;
            
        }
        else
        {
            iterations++;
        }
    }

    private void Spawn(int obstacle)
    {
        int x = -10 * generatedTiles;
        Instantiate(GameObjects[obstacle], new Vector3(mainGame.transform.position.x + x, 0, 0), Quaternion.identity);
    }
}
