using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public float spawnTime;
	public Transform[] spawnPoints;
	public GameObject enemy;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnEnemy", 0f, spawnTime);
	}
	
	// Update is called once per frame
	void SpawnEnemy () {
		/*if (Player.playerHealth.currentHealth <= 0f) {
			return;
		}*/
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		Instantiate (enemy,spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}
