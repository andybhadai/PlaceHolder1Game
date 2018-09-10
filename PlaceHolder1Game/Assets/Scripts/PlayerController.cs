using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

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

    private Vector3 touchPress;
    private Vector3 touchRelease;
    private float dragDistance;
    public float dragDistancePercent;
    private bool newSwipe = false;

    void Start()
    {
        Debug.Log("Starting Unity project!");

        GooglePlayGames.PlayGamesPlatform.Activate();

        //this.CheckIfLoggedIn();

        dragDistance = Screen.height * dragDistancePercent / 100; //dragDistance is 15% height of the screen
    }

    void Update()
    {
        // Will be set to true if the FeetPosition overlaps with ground
        this.IsGrounded = Physics2D.OverlapCircle(this.FeetPosition.position, this.CheckRadius, this.WhatIsGround);
        this.CalculateScore();

        CheckSwipe();
    }

    void FixedUpdate()
    {
        this.MovePlayer();
    }

    private void MovePlayer()
    {
        // Do nothing if player has a cooldown
        if (!this.Movable) return;

        // Automatically run to the right
        this.transform.Translate(Vector3.right * this.RunSpeed * Time.deltaTime);
    }

    private void CheckSwipe()
    {
        // Swipe controlls
        if (Input.touchCount == 1)
        { //Touch screen with 1 finger
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                touchPress = touch.position;
                touchRelease = touch.position;
                newSwipe = true;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                touchRelease = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                newSwipe = false;
            }

            // Check if the Drag distance is bigger than dragDistance variable
            if (Mathf.Abs(touchRelease.x - touchPress.x) > dragDistance || Mathf.Abs(touchRelease.y - touchPress.y) > dragDistance)
            {
                if (newSwipe)
                {
                    //check if the drag is vertical or horizontal
                    if (Mathf.Abs(touchRelease.x - touchPress.x) > Mathf.Abs(touchRelease.y - touchPress.y))
                    {
                        // Horizontal
                        if (touchRelease.x > touchPress.x)
                        {
                            // Right
                        }
                        else
                        {
                            // Left
                        }
                    }
                    else
                    {
                        // Vertical
                        if (touchRelease.y > touchPress.y)
                        {
                            // Up
                            Jump();
                        }
                        else
                        {
                            // Down
                        }
                    }
                }
                newSwipe = false;
            }
            else
            {
                // Tap 
            }
        }
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

    private void Jump()
    {
        // If the player is on the ground and space is pressed, you can jump
        if (this.IsGrounded) GetComponent<Rigidbody2D>().velocity = Vector2.up * this.JumpForce;
    }
}
