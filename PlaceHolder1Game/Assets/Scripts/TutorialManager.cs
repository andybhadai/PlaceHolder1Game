using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {
    public GameObject woodenFence;
    public GameObject house;
    public GameObject rock;
    public GameObject bird;
    public GameObject player;
    public GameObject mainGame;
    public GameObject oilDrop;
    public GameObject oilBarrel;
    public Text tutorialText;

    private bool hasJumped;
    private bool hasDashed;
    private bool hasBrokenRock;
    private bool spawnedFuel;
    private bool spawnedFence;
    private bool spawnedHouse;
    private bool spawnedRock;
    private int tutorialStep = 0;
    private PlayerController playerController;


    void Start()
    {
        playerController = mainGame.GetComponentInChildren<PlayerController>();
    }

    void Update()
    {

        if(tutorialStep < 5) player.GetComponent<GasFill>().gasBar.fillAmount = 1;

        switch (tutorialStep)
        {
            case 0:
                JumpExplain();
                break;
            case 1:
                DashExplain();
                break;
            case 2:
                FillGasExplain();
                break;
            case 3:
                BreakObstacleExplain();
                break;
            case 4:
                SpawnWoodenFence();
                break;
            case 5:
                SpawnHouseObstacle();
                break;
            case 6:
                SpawnRock();
                break;
        }
    }

    private void JumpExplain()
    {
        if (player.transform.position.y > 0 && tutorialStep == 0)
        {
            tutorialText.text = "Swipe left to dash! You can dash into houses and kill birds if you dash into them!";
            tutorialStep = 1;
        }
    }

    private void DashExplain()
    {
        if(tutorialStep == 1 && playerController.isDashing)
        {
            tutorialText.text = "Collect oil drops and jerrycans to fill your fuel-level!";
            tutorialStep = 2;
        }
    }

    private void FillGasExplain()
    {
        if(tutorialStep == 2 && !spawnedFuel)
        {
            tutorialText.text = "Collect oil to fill the fuel!";
            oilDrop.transform.localPosition = new Vector3(player.transform.position.x - 10, -1.25f);
            Instantiate(oilDrop);
            oilBarrel.transform.localPosition = new Vector3(player.transform.position.x - 15, -1.25f);
            Instantiate(oilBarrel);
            spawnedFuel = true;
            tutorialStep = 3;
        }
    }

    private void BreakObstacleExplain()
    {
        if(tutorialStep == 3)
        {
            tutorialText.text = "Collect gas and oildrops to fill your fuel! Tap rocks to break them! Try out everything you learned!";
            tutorialStep = 4;
        }
    }

    private void SpawnWoodenFence()
    {
        if (tutorialStep == 4 && !spawnedFence)
        {
            woodenFence.transform.localPosition = new Vector3(player.transform.position.x - 30, -1.25f);
            Instantiate(woodenFence);
            hasJumped = true;
            spawnedFence = true;
            tutorialStep = 5;
        }
    }

    private void SpawnHouseObstacle()
    {
        if (tutorialStep == 5 && hasJumped && !spawnedHouse)
        {
            house.transform.localPosition = new Vector3(player.transform.position.x - 45, 0f);
            Instantiate(house);
            spawnedHouse = true;
            tutorialStep = 6;
        }
    }

    private void SpawnRock()
    {
        if(tutorialStep == 6 && !spawnedRock)
        {
            rock.transform.localPosition = new Vector3(player.transform.position.x - 70, 0f);
            Instantiate(rock);
            tutorialStep = -1;
            spawnedRock = true;
        }
    }

    public void SetLevel()
    {
        if(tutorialStep > -1 && tutorialStep < 7)
        {
            tutorialStep++;
        }
    }
}
