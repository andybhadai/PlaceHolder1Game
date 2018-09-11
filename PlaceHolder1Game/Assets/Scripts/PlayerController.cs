using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public const string leaderboard_highscore = "CgkI6-femrAJEAIQAQ";

    public float RunSpeed = 2f;
    public float JumpSpeed = 2f;
    public float JumpForce = 1f;
    public float HitBack = 4f;

    public Transform FeetPosition;
    public float CheckRadius;
    public LayerMask WhatIsGround;
    private bool IsGrounded;
    private int TotalDistance = 0;
    public float TimeOut = 2000;
    private bool Movable = true;

    public Text LoggedInText;

    void Start()
    {
        GooglePlayGames.PlayGamesPlatform.Activate();
        //this.Login();
    }

    private void OnConnectionResponse(bool authenticated)
    {
        this.LoggedInText.text = "Getting response!";

        if (authenticated)
        {
            this.LoggedInText.text = "You are logged in!";
        }
        else
        {
            this.LoggedInText.text = "You are not logged in!";
        }
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
        this.LoggedInText.text = $" YOU HAVE RUN {this.TotalDistance * -1}";
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            // Bounce player to the left when he hit an obstacle
            GetComponent<Rigidbody2D>().velocity = Vector2.right * this.HitBack;
            this.Movable = false;

            StartCoroutine(MoveAgainCoroutine(0.5f));
        }
    }

    // Implemented in case the player needs to be stunned for a few seconds
    IEnumerator MoveAgainCoroutine(float timeOut)
    {
        yield return new WaitForSeconds(timeOut);
        this.Movable = true;
    }

    private void GameOver()
    {
        this.AddScore(leaderboard_highscore, this.TotalDistance);
    }

    private void AddScore(string leaderBoardId, long score)
    {
        Social.ReportScore(score, leaderBoardId, success => { });
    }

    private void ShowHighscores()
    {
        Social.ShowLeaderboardUI();
    }

    private void Login()
    {
        this.LoggedInText.text = "You are going to log in!";

        if (Social.localUser.authenticated)
        {
            this.LoggedInText.text = "You are logged in!";
        }
        else
        {
            this.LoggedInText.text = "Logging in...";

            // Log in to Google Games
            Social.localUser.Authenticate(success =>
            {
                this.LoggedInText.text = "Callback";
                //this.OnConnectionResponse(success);

                if (success)
                {
                    this.LoggedInText.text = "You are logged in!";
                }
                else
                {
                    this.LoggedInText.text = "Something went wrong";
                }
            });

            this.LoggedInText.text = "Logging in did not work";
        }
    }
}
