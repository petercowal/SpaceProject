using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	float health;
	public float maxHealth = 100;
	public Slider healthSlider;
	// Use this for initialization
	void Start () {
		health = maxHealth;
		healthSlider.value = health;
	}

	public void takeDamage(float amt){
		health -= amt;
		healthSlider.value = health;

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
			if(health <= 0){
				//Destroy(gameObject);
			}
		}

	}
}
