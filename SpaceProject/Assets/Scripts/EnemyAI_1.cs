﻿using UnityEngine;
using System.Collections;

public class EnemyAI_1 : MonoBehaviour {
	Transform player;
	Rigidbody rb;

	public enum State {Circle = 0, Charge = 1, TurnAround = 2};
	private State state;
	private Vector3 upVector;

	private Vector3 runVector;
	public float accelerationRate;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate = 0.1f;
	private float fireTime;
	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		rb = GetComponent<Rigidbody> ();

		state = State.Circle;
		upVector = Random.onUnitSphere;

	}
	void OnTriggerStay(Collider other){
		if (other.CompareTag ("ProximitySphere")) {
			rb.AddForce (accelerationRate * 0.5f * (transform.position - other.transform.position).normalized, ForceMode.Acceleration);
		}
	}

	void fire(){
		if (Time.time > fireTime) {
			fireTime = Time.time + fireRate;

			Instantiate(shot, shotSpawn.position, Quaternion.LookRotation(player.position - shotSpawn.position + Random.insideUnitSphere*4));
		}
	}

	// Update is called once per frame
	void FixedUpdate () {


		if (state == State.Charge) {
			fire ();
			if ((player.position - transform.position).magnitude > 25) {
				rb.AddForce (accelerationRate * (player.position - transform.position).normalized, ForceMode.Acceleration);
			} else {
				runVector = player.position - transform.position;
				state = State.TurnAround;
			}
		}
		if (state == State.TurnAround) {
			if ((player.position - transform.position).magnitude < 50) {
				rb.AddForce (accelerationRate * (runVector + Vector3.Cross (player.position - transform.position, upVector))
					.normalized, ForceMode.Acceleration);
			} else if ((player.position - transform.position).magnitude < 200) {
				rb.AddForce (runVector.normalized * accelerationRate);
			} else {
				state = State.Circle;
			}
		}
		if (state == State.Circle) {
			if (Random.value < 0.003) {
				state = State.Charge;
			} else {
				rb.AddForce (accelerationRate * (Vector3.Cross (player.position - transform.position, upVector))
					.normalized, ForceMode.Acceleration);
			}
		} 
			
		rb.MoveRotation (Quaternion.LookRotation (rb.velocity, upVector));
	}
}