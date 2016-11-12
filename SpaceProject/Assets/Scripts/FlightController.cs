using UnityEngine;
using System.Collections;

public class FlightController : MonoBehaviour {
	public float forwardSpeed;
	public float strafeSpeed;
	public float rotationRate;
	public float accelerationRate;
	private Rigidbody rb;

	private float fspeed;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		fspeed = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float h = Input.GetAxis("Mouse X");
		float v = -Input.GetAxis("Mouse Y");
		float tilt = 0;
		if (Input.GetKey (KeyCode.Q)) {
			tilt--;
		}
		if (Input.GetKey (KeyCode.E)) {
			tilt++;
		}

		rb.AddRelativeTorque (Vector3.up * h * rotationRate, ForceMode.Acceleration);
		rb.AddRelativeTorque (Vector3.right * v * rotationRate, ForceMode.Acceleration);

		rb.AddRelativeTorque (-Vector3.forward * tilt * rotationRate, ForceMode.Acceleration);

		float f = Input.GetAxis ("Vertical");
		fspeed += f*accelerationRate;
		if (fspeed < -strafeSpeed)
			fspeed = -strafeSpeed;
		if (fspeed > forwardSpeed)
			fspeed = forwardSpeed;
		rb.AddRelativeForce (Vector3.forward * fspeed, ForceMode.Acceleration);

		float s = Input.GetAxis ("Horizontal");
		rb.AddRelativeForce (Vector3.right * s * strafeSpeed, ForceMode.Acceleration);
	}
}