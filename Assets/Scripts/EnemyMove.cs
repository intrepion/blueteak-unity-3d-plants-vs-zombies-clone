using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
	public float movementSpeed;
	public bool canMove;

	// Update is called once per frame
	void Update ()
	{
		if (this.canMove) {
			this.transform.Translate (Vector3.left * this.movementSpeed * Time.deltaTime);
		}
	}
}
