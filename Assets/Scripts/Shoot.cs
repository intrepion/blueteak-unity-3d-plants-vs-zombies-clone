using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
	public float cooldownMax;
	public GameObject projectile;
	public bool hasEnemy;

	private float cooldownCounter;

	// Use this for initialization
	void Start ()
	{
		this.cooldownCounter = this.cooldownMax;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (this.cooldownCounter > 0) {
			this.cooldownCounter -= Time.deltaTime;
		} else {
		}

		RaycastHit hit;
		if (Physics.Raycast (this.transform.position, Vector3.right, out hit, 15)) {
			if (hit.transform.tag == "Enemy") {
				this.hasEnemy = true;
			} else if (hit.transform.tag == "Tower") {
				Shoot shootScript = this.transform.GetComponent<Shoot> ();
				if (shootScript.hasEnemy) {
					this.hasEnemy = true;
				} else {
					this.hasEnemy = false;
				}
			} else {
				this.hasEnemy = false;
			}
		} else {
			this.hasEnemy = false;
		}
		if (this.hasEnemy) {
			if (this.cooldownCounter <= 0) {
				this.cooldownCounter = this.cooldownMax;
				Instantiate (this.projectile, this.transform.position, Quaternion.identity);
			}
		}
	}
}
