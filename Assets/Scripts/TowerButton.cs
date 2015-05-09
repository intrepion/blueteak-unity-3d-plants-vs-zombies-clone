using UnityEngine;
using System.Collections;

public class TowerButton : MonoBehaviour
{
	public SetTower setTowerScript;

	public void TowerShoot ()
	{
		this.setTowerScript.selected = 0;
	}
	
	public void TowerIncome ()
	{
		this.setTowerScript.selected = 1;
	}

	public void TowerExpensive ()
	{
		this.setTowerScript.selected = 2;
	}
}
