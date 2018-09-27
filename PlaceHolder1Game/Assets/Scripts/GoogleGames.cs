using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoogleGames : MonoBehaviour {

    public Text LoggedIn;

	// Use this for initialization
	void Start () {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();

        //Login();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //private void Login()
    //{
    //    Social.localUser.Authenticate(success => {
    //        if (success)
    //        {
    //            LoggedIn.text = "Logged in!";
    //        }
    //        else
    //        {
    //            LoggedIn.text = "Not logged in!";
    //        }
    //    });
    //}
}
