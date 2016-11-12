using UnityEngine;
using System.Collections;

public class FieldGenerator : MonoBehaviour {
	public float inactiveRadius = 2000;
	public float activeRadius = 1000;
	public float radius;
	public GameObject objectType;
	public int population = 100;

	bool active;

	public Transform player;

	private GameObject[] objects;
	// Use this for initialization
	void Awake () {
		active = false;
		objects = new GameObject[population];
	}
	void Update() {
		if ((player.position - transform.position).magnitude < activeRadius && !active) {
			active = true;
			for (int i = 0; i < population; i++) {
				objects[i] = (GameObject)Instantiate (objectType, transform.position + (radius * Random.insideUnitSphere), Random.rotation);
			}
		}
		else if ((player.position - transform.position).magnitude > inactiveRadius && active) {
			active = false;
			for (int i = 0; i < population; i++) {
				if(objects[i] != null)
					Destroy (objects [i]);
			}
		}
	}

}
