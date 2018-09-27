using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class Highscore : MonoBehaviour {
    private string privateKey = "2_D01Utjf0SPm_tF_dmFGQKMx2S-zNbUyJgmB1N8X3IQ";
    private string publicKey = "5bac93de613a88061420fceb";
    private string url = "http://dreamlo.com/lb/";

    public void AddHighscore()
    {
        // If the saved values are not found, exit the method
        if (!PlayerPrefs.HasKey("score") || !PlayerPrefs.HasKey("username")) return;

        float highscore = PlayerPrefs.GetFloat("score") * -1;
        string username = PlayerPrefs.GetString("username");

        // Send highscore to server
        UnityWebRequest webRequest = UnityWebRequest.Get($"{url}/{privateKey}/add/{username}/{(int) highscore}");
        webRequest.SendWebRequest();

        if (webRequest.isNetworkError || webRequest.isHttpError)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            Debug.Log("Saved highscore!");
        }
    }

    public void GetHighscores()
    {
    }
}
