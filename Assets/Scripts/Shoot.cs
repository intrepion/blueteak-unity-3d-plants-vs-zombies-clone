using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
	public float cooldown;
	public GameObject projectile;

	private float cooldownCounter;

	// Use this for initialization
	void Start ()
	{
		this.cooldownCounter = this.cooldown;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (this.cooldownCounter > 0) {
			this.cooldownCounter -= Time.deltaTime;
		} else {
			RaycastHit hit;
			if (Physics.Raycast (this.transform.position, Vector3.right, out hit, 15))
			{
				if (hit.transform.tag == "Enemy") {
					this.cooldownCounter = this.cooldown;
					Instantiate (this.projectile, this.transform.position, Quaternion.identity);
				}
			}
		}
	}
}
