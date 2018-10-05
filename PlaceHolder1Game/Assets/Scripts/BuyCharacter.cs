using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyCharacter : MonoBehaviour {

	public GameObject CharacterController;
	public GameObject PriceButton;
	public Text Textbox;
	public int price;
	private bool bought;
	public string saveName;

	public bool resetBought;

	private CharacterSelectionScript characterSelectionScript;

	// Use this for initialization
	void Start () {
		characterSelectionScript = CharacterController.GetComponent<CharacterSelectionScript>();

		ResetBought();
		GetBought();

		Textbox.text = price.ToString();
		SetButton();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SetButton()
	{
		if(IsBought())
			PriceButton.SetActive(false);
	}

	public bool IsBought()
	{
		return bought;
	}

	public void Buy()
	{
		int amountOfCoins = characterSelectionScript.TotalCoins();
		
		if(amountOfCoins >= price)
		{
			amountOfCoins -= price;
			bought = true;
			SetButton();
			SaveCoins(amountOfCoins);
			PlayerPrefs.SetInt(saveName, 1);
		}
	}

	void SaveCoins(int amountOfCoins)
	{
		PlayerPrefs.SetInt("amountOfCoins", amountOfCoins);
		characterSelectionScript.UpdateCoins();
	}

	void GetBought()
	{
		int tmp = PlayerPrefs.GetInt(saveName, 0);
		if(tmp == 0){
			bought = false;
		}
		else
		{
			bought = true;
		}
	}

	void ResetBought()
	{
		if(resetBought)
			PlayerPrefs.SetInt(saveName, 0);
	}
}
