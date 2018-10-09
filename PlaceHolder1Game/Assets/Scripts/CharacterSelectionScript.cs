using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectionScript : MonoBehaviour {

    public GameObject[] Characters;
	private int hovering;
	public int selected;
	public Text CoinsTotal;
	private int amountOfCoins;

	// Use this for initialization
	void Start () {
		selected = PlayerPrefs.GetInt("SelectedCharacter", 0);
		hovering = selected;
		UpdateCharacter();

		amountOfCoins = GetAmountOfCoins();
		SetCoinText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NextCharacter()
	{
		if(hovering < Characters.Length-1)
		{
			hovering++;
			UpdateCharacter();
		}
	}

	public void PrevCharacter()
	{
		if(hovering > 0)
		{
			hovering--;
			UpdateCharacter();
		}
	}

	void UpdateCharacter()
	{
		for(int i= 0; i < Characters.Length; i++)
		{
			if(hovering == i)
			{
				Characters[i].SetActive(true);
			}
			else
			{
				Characters[i].SetActive(false);
			}
		}
	}

	public void SelectCharacter()
	{
		if(Characters[hovering].GetComponent<BuyCharacter>().IsBought())
		{
			selected = hovering;
			PlayerPrefs.SetInt("SelectedCharacter", selected);
			SceneManager.LoadScene("StartMenu");
		}
	}

	public int TotalCoins()
	{
		return amountOfCoins;
	}

	public void UpdateCoins()
	{
		amountOfCoins = GetAmountOfCoins();
		SetCoinText();
	}

	private int GetAmountOfCoins()
	{
		return PlayerPrefs.GetInt("amountOfCoins", 0);
	}

	private void SetCoinText()
	{
		CoinsTotal.text = amountOfCoins.ToString();
	}
}
