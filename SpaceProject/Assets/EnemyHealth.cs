using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public int maxHealth = 10;
	private int health;

	public GameObject hitEffect;
	// Use this for initialization
	void Start () {
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) 
	{
		print ("Hit by trigger");
		if (other.CompareTag("PlayerShot"))
		{
			Instantiate (hitEffect, other.transform.position, other.transform.rotation);

			Destroy(other.gameObject);
			health--;
			if(health <= 0){
				Destroy(gameObject);
			}
		}

	}
}
