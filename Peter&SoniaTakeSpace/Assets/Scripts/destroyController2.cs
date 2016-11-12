using UnityEngine;
using System.Collections;

public class destroyController2 : MonoBehaviour {
	int NUM_PIECES = 8;
	public GameObject asteroid;
	GameObject clone;
	Rigidbody rb;
	int scaleFactor = 8; 

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space))
		{
			Destroy(gameObject);
			for(int i = 0; i < NUM_PIECES; i++) {
				clone = (GameObject)Instantiate(asteroid, Random.insideUnitSphere * 2, transform.rotation);
				clone.GetComponent<Rigidbody>().velocity = Random.insideUnitSphere * scaleFactor;
			}
		}


	}
}
	