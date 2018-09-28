using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasFill : MonoBehaviour {

	public Image gasBar; 
	public float ringFillAmount;

	// Use this for initialization
	void Start () {
		gasBar = gasBar.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		gasBar.fillAmount -= 0.001f;

		if(gasBar.fillAmount == 0)
		{
			this.GetComponent<EndGameTrigger>().GameOver();
		}
	}

	public void MaxGas() 
	{
		gasBar.fillAmount = 1;
	}

	public void FillGas() 
	{
		gasBar.fillAmount += ringFillAmount;
	}
}
