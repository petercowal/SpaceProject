using UnityEngine;
using System.Collections;

public class ShotController : MonoBehaviour {
	public GameObject shot;

	public Transform shotSpawn;
	public float fireRate;

	private float fireTime;
	bool right;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1") && Time.time > fireTime) {
			Vector3 pos = shotSpawn.position;
			if (right)
				pos += shotSpawn.right * 1.5f;
			else
				pos -= shotSpawn.right * 1.5f;
			right = !right;
			Instantiate (shot, pos, Quaternion.Lerp(shotSpawn.rotation, Random.rotation, 0.02f));

			fireTime = Time.time + fireRate;
		}
	}
}
