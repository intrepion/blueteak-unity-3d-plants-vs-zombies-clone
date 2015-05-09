using UnityEngine;
using System.Collections;

public class SetTower : MonoBehaviour
{
	public int selected;
	public GameObject[] towers;
	public float[] prices;
	public GameObject tile;

	private Money moneyScript;

	// Use this for initialization
	void Start ()
	{
		this.moneyScript = GameObject.Find ("Game Logic").GetComponent<Money> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 20)) {
			if (hit.transform.tag == "Tile") {
				this.tile = hit.transform.gameObject;
			} else {
				this.tile = null;
			}
		}
		if (Input.GetMouseButtonDown (0) && this.tile != null) {
			TileTaken tileTakenScript = this.tile.GetComponent<TileTaken> ();
			if (!tileTakenScript.isTaken && (this.moneyScript.money - prices[this.selected]) >= 0) {
				this.moneyScript.money -= prices[this.selected];
				Vector3 pos = new Vector3 (this.tile.transform.position.x, 1f, this.tile.transform.position.z);
				tileTakenScript.tower = (GameObject)Instantiate(towers[this.selected], pos, Quaternion.identity);
				tileTakenScript.isTaken = true;
			}
		}
	}
}
