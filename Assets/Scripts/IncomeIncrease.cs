using UnityEngine;
using System.Collections;

public class IncomeIncrease : MonoBehaviour
{
	public float cooldownMax;
	public float income;

	private float cooldownCounter;
	private Money moneyScript;

	// Use this for initialization
	void Start ()
	{
		this.cooldownCounter = this.cooldownMax;
		this.moneyScript = GameObject.Find ("Game Logic").GetComponent<Money> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (this.cooldownCounter > 0) {
			this.cooldownCounter -= Time.deltaTime;
		} else {
			this.cooldownCounter = this.cooldownMax;
			this.moneyScript.money += this.income;
		}
	}
}
