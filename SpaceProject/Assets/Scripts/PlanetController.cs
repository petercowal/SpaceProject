using UnityEngine;
using System.Collections;

public class PlanetController : MonoBehaviour {

	public Material m1;
	public Material m2;
	public Material m3;
	public float min = .3f;
	public float max = 1f;

	// Use this for initialization
	void Start () {
		Renderer rend = GetComponent<Renderer>();


		int rand = Random.Range (1, 3);
		if (rand == 1) {
			if (rend != null) {
				rend.material = m1;
			}
		} else if (rand == 1) {
			if (rend != null) {
				rend.material = m2;
			}
		} else {
			if (rend != null) {
				rend.material = m3;
			}
		}


		float scale = Random.Range (min, max);
		gameObject.transform.localScale = gameObject.transform.localScale * scale;

	}

}
