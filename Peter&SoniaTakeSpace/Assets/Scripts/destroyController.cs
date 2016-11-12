using UnityEngine;
using System.Collections;

public class destroyController : MonoBehaviour {
	public GameObject remains;
	public GameObject pushSphere;
	int sizeCounter = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space))
		{
			Instantiate(remains, transform.position, transform.rotation);
			Instantiate (pushSphere, transform.position, transform.rotation);
			Destroy(gameObject);
		}

		if (sizeCounter < 5) {	
			pushSphere.transform.localScale = new Vector3 (pushSphere.transform.localScale.x * 1.1f, 
				pushSphere.transform.localScale.y * 1.1f, pushSphere.transform.localScale.z * 1.1f);
			sizeCounter++;
		}
	}
}
