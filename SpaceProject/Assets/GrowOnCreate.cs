using UnityEngine;
using System.Collections;

public class GrowOnCreate : MonoBehaviour {
	float scalePercent;
	Vector3 maxScale;
	// Use this for initialization
	void Start () {
		maxScale = transform.localScale;
		scalePercent = 0.01f;
		transform.localScale = maxScale * scalePercent;
	}
	
	// Update is called once per frame
	void Update () {
		scalePercent = Mathf.Min (1f, scalePercent + 0.03f);
		transform.localScale = maxScale * scalePercent;
	}
}
