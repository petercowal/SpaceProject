﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	float health;
	public float maxHealth = 100;
	public Slider healthSlider;
	public float multiplier = .25f;
	// Use this for initialization
	private GameController gameController;

	void Start () {
		health = maxHealth;
		healthSlider.value = health;
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
	}

	public void takeDamage(float amt){
		health -= amt*multiplier;
		healthSlider.value = health;
		if(health <= 0){
			gameController.GameOver ();
		}

	}
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision collision){
		if (collision.relativeVelocity.magnitude > 5) {
			takeDamage (collision.relativeVelocity.magnitude);
		}
	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.CompareTag("EnemyShot"))
		{
			//Instantiate (hitEffect, other.transform.position, other.transform.rotation);

			Destroy(other.gameObject);
			takeDamage (1);

		}

	}
}
