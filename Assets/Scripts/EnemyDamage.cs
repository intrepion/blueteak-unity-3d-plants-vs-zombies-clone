using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour
{
	public float damage;
	public float cooldownMax;

	private EnemyMove enemyMoveScript;
	private float cooldownCounter;

	// Use this for initialization
	void Start ()
	{
		this.enemyMoveScript = this.gameObject.GetComponent<EnemyMove> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (this.cooldownCounter > 0) {
			this.cooldownCounter -= Time.deltaTime;
		}
		RaycastHit hit;
		if (Physics.Raycast (this.transform.position, Vector3.left, out hit, 0.6f)) {
			if (hit.transform.tag == "Tower") {
				if (this.cooldownCounter <= 0) {
					Health healthScript = hit.transform.gameObject.GetComponent<Health> ();
					healthScript.health -= this.damage;
					this.cooldownCounter = this.cooldownMax;
				}
			} else if (hit.transform.tag == "House") {
				GameObject.Find ("Game Logic").GetComponent<LoseGame> ().lost = true;
			}
			this.enemyMoveScript.canMove = false;
		} else if (this.enemyMoveScript.canMove == false) {
			this.enemyMoveScript.canMove = true;
		}
	}
}
