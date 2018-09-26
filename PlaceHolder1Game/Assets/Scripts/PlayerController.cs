using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public const string leaderboard_highscore = "CgkI6-femrAJEAIQAQ";

    public float RunSpeed = 4f;
    public float JumpSpeed = 2f;
    public float JumpForce = 1f;
    public float HitBack = 4f;

    public Transform FeetPosition;
    public float CheckRadius;
    public LayerMask WhatIsGround;
    // private bool IsGrounded;
    private int TotalDistance = 0;
    public float TimeOut = 2000;
    private bool Movable = true;
    private Vector3 touchPress;
    private Vector3 touchRelease;
    public float dragDistance;
    //public float dragDistancePercent;
    private bool newSwipe = false;
    public GameObject ScoreBoard;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI LoggedIn;

    public float maxDashTime = 1.0f;
    public float dashSpeed = 1.0f;
    public float dashStoppingSpeed = 0.1f;
    private float currentDashTime;
    private bool isDashing = false;
    private bool hasDashed;
    private bool DashDirection; //True = Left, False = Right

    public GameObject MainGame;
    Animator animator;

    private float yOnDash;

    void Start()
    {
        //GooglePlayGames.PlayGamesPlatform.Activate();

        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();

        //this.Login();

        animator = GetComponent<Animator>();

        //This needs to be here otherwise the player dashes at the start of the game
        currentDashTime = maxDashTime;
    }

    private void Login()
    {
        Social.localUser.Authenticate(success => {
            if (success)
            {
                LoggedIn.text = "Logged in!";
            }
            else
            {
                LoggedIn.text = "Not logged in!";
            }
        });
    }

    void Update()
    {
        if (IsGrounded()) {
            hasDashed = false;
            animator.SetBool("isJumpingUp", false);
        }
        else
        {
            animator.SetBool("isJumpingUp", true);
        }

        this.CalculateScore();

        if(TotalDistance % 100 == 0)
        {
            ShowAndResetScoreBoard();
        }

        CheckSwipe();
    }

    void FixedUpdate()
    {
        //this.MovePlayer();

        UpdateDash();
    }


    private void MovePlayer()
    {
        // Do nothing if player has a cooldown
        if (!this.Movable) return;

        // Automatically run to the right
        this.transform.Translate(Vector3.left * this.RunSpeed * Time.deltaTime);
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
                            //Dash(false); You cannot Dash to the right side
                        }
                        else
                        {
                            // Left
                            Dash(true);
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
                            Dive();
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
        this.TotalDistance = (int)MainGame.transform.position.x;
    }

    private void ShowAndResetScoreBoard()
    {
        Score.text = $"{TotalDistance * - 1} M";
        ScoreBoard.transform.localPosition = new Vector3(-800, -119);
        ScoreBoard.SetActive(true);
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

    public void ShowHighscores()
    {
        Debug.Log("Highscore");
        Social.ShowLeaderboardUI();
    }

    private void Jump()
    {
        // If the player is on the ground, you can jump
        if (IsGrounded())
        {
            animator.SetBool("isJumpingUp", true);
            GetComponent<Rigidbody2D>().velocity = Vector2.up * this.JumpForce;
        }
    }

    private void Dive()
    {
        // If the player is in the air, you can jump
        if (!IsGrounded()) GetComponent<Rigidbody2D>().velocity = Vector2.down * this.JumpForce;
    }

    private void Dash(bool left)
    {
        // If player is in the air, you can dash
        if (CanDash()) {
            if (left) DashDirection = true;
            else DashDirection = false;
            currentDashTime = 0.0f;
            hasDashed = true;
            isDashing = true;
            yOnDash = transform.position.y;
        }
    }

    private bool CanDash()
    {
        // return (!IsGrounded() && !hasDashed);
        return (!hasDashed);
    }

    private void UpdateDash()
    {
        if (currentDashTime < maxDashTime)
        {
            Vector3 tmp = transform.position;
            tmp.y = yOnDash;
            transform.position = tmp;
            currentDashTime += dashStoppingSpeed;
            if (DashDirection) MainGame.transform.Translate(Vector3.left * dashSpeed * Time.deltaTime);
            else MainGame.transform.Translate(Vector3.right * dashSpeed * Time.deltaTime);
        }
        else
        {
            isDashing = false;
        }
    }

    private bool IsGrounded()
    {// Will be set to true if the FeetPosition overlaps with ground
        return Physics2D.OverlapCircle(this.FeetPosition.position, this.CheckRadius, this.WhatIsGround);
    }

    void OnTriggerEnter2D (Collider2D Collision)
    {
        if (Collision.transform.gameObject.tag == "DashableObstacle" && isDashing == true)
        {
            Collision.transform.Translate(10f, 0, 0);
        } else if (Collision.transform.gameObject.tag == "Ring") {
            // Add fuel
        } else {
            this.GetComponent<EndGameTrigger>().GameOver();
        }
    }
}
