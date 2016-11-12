using UnityEngine;
using System.Collections;

public class DeathTimer : MonoBehaviour {
	public float life;
	private float deathTime;
	// Use this for initialization
	void Start () {
		deathTime = Time.time + life;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > deathTime) {
			Destroy (gameObject);
		}
	}
}
