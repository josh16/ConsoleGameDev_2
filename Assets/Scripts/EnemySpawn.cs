using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

	[SerializeField] private GameObject enemyPrefab = null;
	[SerializeField] private Transform enemySpawnPoint = null;

	//Zach's and Jon's script	

	void Update ()
	{

	}

	public float RateOfSpawn;

	void Start ()
	{
		StartCoroutine(ShootCoroutine(this.RateOfSpawn));
	}


	private IEnumerator ShootCoroutine (float delay)
	{
		while (true)
		{
			// Shoot every "delay" seconds.
			yield return new WaitForSeconds(delay);
           randSpawn();

			
		}
	}

	public void randSpawn(){
		var num = Random.Range (1, 30);
		if (num <= 15) {
			enemies ();
		} else {
			return;
		}
	}


	public void enemies(){

		GameObject enemy = Instantiate (this.enemyPrefab) as GameObject;
		enemy.transform.position = this.enemySpawnPoint.transform.position;
		enemy.transform.rotation = this.enemySpawnPoint.transform.rotation;

	}

	


}
