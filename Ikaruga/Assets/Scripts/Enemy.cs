using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyBoundary {
	public float xMin, xMax, yMin, yMax;
}

public class Enemy : MonoBehaviour {

	public float speed;
	public float tilt;
	public EnemyBoundary enemyBoundary;

	public GameObject shot;
	public GameObject enemyKiller;
	public GameObject player;
	public Transform shotSpawn;
	public float fireRate;
	public float secondsToDestroy;

	private float nextFire;


	void Start(){
		DestroyShip();
	}

	// Update is called once per frame
	void Update () {
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			// GameObject clone = 
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation); //as GameObject;
			GetComponent<AudioSource>().Play();
		}	
	}

	void FixedUpdate(){
		float moveHorizontal = enemyKiller.transform.position.x;
		player = GameObject.Find ("Player");
		float moveVertical = player.transform.position.y;

		Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
		GetComponent<Rigidbody>().velocity = movement * speed;

		GetComponent<Rigidbody> ().position = new Vector3 (
			Mathf.Clamp(GetComponent<Rigidbody> ().position.x, enemyBoundary.xMin, enemyBoundary.xMax),
			Mathf.Clamp(GetComponent<Rigidbody> ().position.y, enemyBoundary.yMin, enemyBoundary.yMax),
			0.0f);

		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0.0f, -90.0f, GetComponent<Rigidbody> ().velocity.y * -tilt);
	}
	 
	void DestroyShip(){
		Destroy(gameObject, secondsToDestroy);
	}
}
