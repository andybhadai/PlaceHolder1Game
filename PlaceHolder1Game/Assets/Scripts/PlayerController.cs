using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float RunSpeed = 2f;
    public float JumpSpeed = 2f;
    public float JumpForce = 1f;
    public float HitBack = 4f;

    public Transform FeetPosition;
    public float CheckRadius;
    public LayerMask WhatIsGround;
    private bool IsGrounded;
    private int TotalDistance = 0;
    private int TotalHit = 0;
    public float TimeOut = 2000;
    private bool Movable = true;

    void Start()
    {
        Debug.Log("Starting Unity project!");

        GooglePlayGames.PlayGamesPlatform.Activate();

        //this.CheckIfLoggedIn();
    }

    void Update()
    {
        // Will be set to true if the FeetPosition overlaps with ground
        this.IsGrounded = Physics2D.OverlapCircle(this.FeetPosition.position, this.CheckRadius, this.WhatIsGround);
        this.CalculateScore();
    }

    void FixedUpdate()
    {
        this.MovePlayer();
    }

    private void MovePlayer()
    {
        // Do nothing if player has a cooldown
        if (!this.Movable) return;

        // If the player is on the ground and space is pressed, you can jump
        if (this.IsGrounded && Input.GetMouseButtonDown(0)) GetComponent<Rigidbody2D>().velocity = Vector2.up * this.JumpForce;

        // Automatically run to the right
        this.transform.Translate(Vector3.right * this.RunSpeed * Time.deltaTime);
    }

    private void CalculateScore()
    {
        this.TotalDistance = (int)GetComponent<Rigidbody2D>().transform.position.x;
    }

    private void CheckIfLoggedIn()
    {
        if (Social.localUser.authenticated)
        {
            Debug.Log("You have been logged in!");
        }
        else
        {
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    Debug.Log("Logged in!");
                }
            });
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            // Bounce player to the left when he hit an obstacle
            GetComponent<Rigidbody2D>().velocity = Vector2.right * this.HitBack;
            this.Movable = false;
            this.TotalHit++;

            StartCoroutine(MoveAgainCoroutine(0.5f));
        }
    }

    IEnumerator MoveAgainCoroutine(float timeOut)
    {
        yield return new WaitForSeconds(timeOut);
        this.Movable = true;
    }

    private void GameOver()
    {
        int highscore = PlayerPrefs.GetInt("HighScore");

        if (highscore > this.TotalDistance) PlayerPrefs.SetInt("HighScore", this.TotalDistance);
    }
}
