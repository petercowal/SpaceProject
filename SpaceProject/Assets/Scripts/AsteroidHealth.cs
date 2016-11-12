using UnityEngine;
using System.Collections;

public class AsteroidHealth : MonoBehaviour {
	public int maxHealth = 3;
	private int health;
	private GameController gameController;

	public GameObject hitEffect;
	// Use this for initialization
	void Start () {
		health = maxHealth;
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.CompareTag("PlayerShot"))
		{
			Instantiate (hitEffect, other.transform.position, other.transform.rotation);

			Destroy(other.gameObject);
			health--;
			if(health <= 0){
				gameController.AddScore (1);
				Destroy(gameObject);

			}
		}

	}
}
