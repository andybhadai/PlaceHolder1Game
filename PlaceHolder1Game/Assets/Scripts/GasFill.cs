using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasFill : MonoBehaviour {

	public Image gasBar;
	public float gasLoseAmount;
	public float ringFillAmount;
	public float dashCostAmount;

	// Use this for initialization
	void Start () {
		gasBar = gasBar.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		gasBar.fillAmount -= gasLoseAmount;

		if(gasBar.fillAmount == 0)
		{
            this.GetComponent<PlayerController>().GameOver();
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

	public void LoseGas()
	{
		gasBar.fillAmount -= dashCostAmount;
	}
}
