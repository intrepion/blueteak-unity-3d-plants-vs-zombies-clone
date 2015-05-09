using UnityEngine;
using System.Collections;

public class LoseGame : MonoBehaviour
{
	public bool lost;

	private Money moneyScript;
	private float initMoney;
	private WaveManager waveManagerScript;

	// Use this for initialization
	void Start ()
	{
		this.moneyScript = this.gameObject.GetComponent<Money> ();
		this.waveManagerScript = this.gameObject.GetComponent<WaveManager> ();
		this.initMoney = this.moneyScript.money;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (this.lost) {
			this.lost = false;
			this.waveManagerScript.numberOut = 0;
			this.waveManagerScript.ResetCooldown ();
			GameObject[] towers = GameObject.FindGameObjectsWithTag ("Tower");
			GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
			for (int i = 0; i < towers.Length; i++) {
				Destroy (towers [i]);
			}
			for (int i = 0; i < enemies.Length; i++) {
				Destroy (enemies [i]);
			}
			GameObject[] tiles = GameObject.FindGameObjectsWithTag ("Tile");
			for (int i = 0; i < tiles.Length; i++) {
				TileTaken tileTakenScript = tiles [i].GetComponent<TileTaken> ();
				tileTakenScript.isTaken = false;
			}
			GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");
			for (int i = 0; i < projectiles.Length; i++) {
				Destroy (projectiles [i]);
			}
			this.moneyScript.money = this.initMoney;
		}
	}
}
