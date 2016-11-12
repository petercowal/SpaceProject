using UnityEngine;
using System.Collections;

public class destroyController2 : MonoBehaviour {
	public int NUM_PIECES = 10;
	public GameObject asteroid;
	public GameObject asteroid1;
	public GameObject asteroid2;
	GameObject clone;
	int scaleFactor = 8; 
	int astType;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space))
		{
			Destroy(gameObject);
			for(int i = 0; i < NUM_PIECES; i++) {
				astType = Random.Range (0, 2);
				if (astType == 0) {
					clone = (GameObject)Instantiate (asteroid, Random.insideUnitSphere * 2, Random.rotation);
				} else if (astType == 1) {
					clone = (GameObject)Instantiate (asteroid1, Random.insideUnitSphere * 2, Random.rotation);
				} else {
					clone = (GameObject)Instantiate (asteroid2, Random.insideUnitSphere * 2, Random.rotation);
				}
				clone.GetComponent<Rigidbody>().velocity = Random.insideUnitSphere * scaleFactor;
				float scale = Random.Range (.01f, .3f);
				clone.transform.localScale += new Vector3(scale, scale, scale);
			}
		}


	}
}
	