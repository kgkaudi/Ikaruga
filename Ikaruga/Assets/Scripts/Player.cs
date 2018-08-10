﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}

public class Player : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;

	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			// GameObject clone = 
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation); //as GameObject;
			GetComponent<AudioSource>().Play();
		}
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
		GetComponent<Rigidbody>().velocity = movement * speed;

		GetComponent<Rigidbody> ().position = new Vector3 (
			Mathf.Clamp(GetComponent<Rigidbody> ().position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp(GetComponent<Rigidbody> ().position.y, boundary.yMin, boundary.yMax),
			0.0f);

		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0.0f, 90.0f, GetComponent<Rigidbody> ().velocity.y * -tilt);
	}
}
