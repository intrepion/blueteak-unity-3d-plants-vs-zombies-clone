using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneyLabel : MonoBehaviour
{
	public Money moneyScript;
	public Text moneyText;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		this.moneyText.text = "Money: " + this.moneyScript.money;
	}
}
