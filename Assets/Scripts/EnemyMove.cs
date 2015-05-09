using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
	public float movementSpeed;
	
	// Update is called once per frame
	void Update ()
	{
		this.transform.Translate (Vector3.left * this.movementSpeed * Time.deltaTime);
	}
}
