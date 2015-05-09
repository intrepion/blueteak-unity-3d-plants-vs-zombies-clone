using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour
{
	public bool isTower;

	private Health healthScript;
	private Money moneyScript;
	private EnemyStats enemyStatsScript;

	// Use this for initialization
	void Start ()
	{
		this.healthScript = this.gameObject.GetComponent<Health> ();
		this.moneyScript = GameObject.Find ("Game Logic").GetComponent<Money> ();
		if (!this.isTower) {
			this.enemyStatsScript = this.gameObject.GetComponent<EnemyStats> ();
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (this.healthScript.health <= 0f) {
			if (this.isTower) {
				Destroy (this.gameObject);
			} else {
				this.moneyScript.money += this.enemyStatsScript.worth;
				Destroy (this.gameObject);
			}
		}
	}
}
