using UnityEngine;
using System.Collections;

public class FieldGenerator : MonoBehaviour {
	public float activeRadius;
	public float radius;
	public GameObject objectType;
	public int population;
	// Use this for initialization
	void Awake () {
		for (int i = 0; i < population; i++) {
			Instantiate (objectType, transform.position + (radius * Random.insideUnitSphere), Random.rotation);
		}
	}

}
