using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;

public class Settings : MonoBehaviour {
    public Sprite SoundIconOn;
    public Sprite SoundIconOff;
    public Button Button;

	// Use this for initialization
	void Start () {
        SetSprite();
	}

    public void ToggleSound()
    {
        PlayerPrefs.SetInt("soundOn", Convert.ToInt32(!GetPlayerSoundOn()));
        PlayerPrefs.Save();

        SetSprite();
    }

    bool GetPlayerSoundOn()
    {
        return Convert.ToBoolean(PlayerPrefs.GetInt("soundOn", 1));
    }

    private void SetSprite()
    {
        if (GetPlayerSoundOn())
        {
            Button.GetComponent<Image>().sprite = SoundIconOn;
        }
        else
        {
            Button.GetComponent<Image>().sprite = SoundIconOff;
        }
    }

    public void CoinCheat()
    {
        PlayerPrefs.SetInt("amountOfCoins", 150);
    }
}
