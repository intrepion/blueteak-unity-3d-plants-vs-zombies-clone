using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	public float movementSpeed;
	public float damage;
	public Vector3 initialPosition;
	public GameObject explosion;

	// Use this for initialization
	void Start ()
	{
		this.initialPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.transform.Translate (Vector3.right * this.movementSpeed * Time.deltaTime);
		if (Vector3.Distance (this.transform.position, this.initialPosition) > 20) {
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.tag == "Enemy") {
			collider.GetComponent<Health> ().health -= this.damage;
			// Create Particles
			Destroy (this.gameObject);
		}
	}
}
