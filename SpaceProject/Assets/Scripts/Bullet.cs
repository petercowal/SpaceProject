using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float speed;
	// Update is called once per frame
	void Start () {
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
		
}
