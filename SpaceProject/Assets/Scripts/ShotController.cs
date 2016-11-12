using UnityEngine;
using System.Collections;

public class ShotController : MonoBehaviour {
	public GameObject shot;
	private Rigidbody rb;
	public Transform shotSpawn;
	public float fireRate;
	public float fireWidth;
	private float fireTime;
	bool right;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1") && Time.time > fireTime && rb.velocity.magnitude < 40) {
			Vector3 pos = shotSpawn.position;
			if (right)
				pos += shotSpawn.right * fireWidth;
			else
				pos -= shotSpawn.right * fireWidth;
			right = !right;
			Instantiate (shot, pos, Quaternion.Lerp(shotSpawn.rotation, Random.rotation, 0.02f));

			fireTime = Time.time + fireRate;
		}
	}
}
