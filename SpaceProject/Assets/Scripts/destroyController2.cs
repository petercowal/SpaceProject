using UnityEngine;
using System.Collections;

public class destroyController2 : MonoBehaviour {
	public int NUM_PIECES = 10;
	public GameObject asteroid;
	public GameObject asteroid1;
	public GameObject asteroid2;
	GameObject clone;
	int scaleFactor = 2; 
	int astType;

	public GameObject hitEffect;
	public int maxHealth = 10;
	private int health;
	private GameController gameController;
	// Use this for initialization
	void Start () {
		health = maxHealth;
		GetComponent<Rigidbody> ().AddRelativeTorque (Random.insideUnitSphere, ForceMode.VelocityChange);
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
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
				for(int i = 0; i < NUM_PIECES; i++) {
					astType = Random.Range (0, 2);
					if (astType == 0) {
						clone = (GameObject)Instantiate (asteroid, transform.position + Random.insideUnitSphere * 4, Random.rotation);
					} else if (astType == 1) {
						clone = (GameObject)Instantiate (asteroid1, transform.position + Random.insideUnitSphere * 4, Random.rotation);
					} else {
						clone = (GameObject)Instantiate (asteroid2, transform.position + Random.insideUnitSphere * 4, Random.rotation);
					}
					clone.GetComponent<Rigidbody>().velocity = Random.insideUnitSphere * scaleFactor;
					float scale = Random.Range (.01f, .3f);
					clone.transform.localScale += new Vector3(scale, scale, scale);
				}
			}
		}

	}

}
	