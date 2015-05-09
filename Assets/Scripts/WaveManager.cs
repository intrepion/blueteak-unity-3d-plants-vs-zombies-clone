using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour
{
	public int numberOut;
	public GameObject[] enemies;
	public float cooldownMax;
	public float initialPause;

	private float cooldownCounter;

	// Use this for initialization
	void Start ()
	{
		this.ResetCooldown ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (this.cooldownCounter > 0) {
			this.cooldownCounter -= Time.deltaTime;
		} else {
			this.cooldownCounter = this.cooldownMax;
			Vector3 pos = new Vector3 (4, 1, Random.Range (-2, 3));
			int index = Random.Range (0, this.enemies.Length);
			Instantiate (this.enemies[index], pos, Quaternion.identity);
			this.numberOut++;
		}
	}

	public void ResetCooldown()
	{
		this.cooldownCounter = this.cooldownMax * this.initialPause;
	}
}
