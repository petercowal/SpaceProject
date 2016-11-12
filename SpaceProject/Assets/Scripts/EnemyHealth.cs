using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public int maxHealth = 10;
	private int health;
	private GameController gameController;

	public GameObject hitEffect;
	public GameObject deathEffect;
	public AudioClip hitClip;
	public AudioClip deathClip;
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
			if (health <= 0) {
				gameController.addKillShipScore (1);
				Destroy (gameObject);
				Instantiate (deathEffect, transform.position, transform.rotation);
				//GetComponent<AudioSource> ().clip = deathClip;
				//GetComponent<AudioSource> ().Play ();
			} else {
				//GetComponent<AudioSource> ().clip = hitClip;
				//GetComponent<AudioSource> ().Play ();
			}
		}

	}
}
