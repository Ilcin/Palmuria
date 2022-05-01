using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FitToFrustum : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Camera camera = GetComponentInParent<Camera> ();
		if (camera == null) {
			Debug.Log ("FitToFrustum did not find parent Camera", this);
		}
		var frustumHeight = 2.0f * camera.farClipPlane * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
		Debug.Log ("frustumHeight=" + frustumHeight);
		transform.localScale = new Vector3(frustumHeight, frustumHeight, 1);
	}
}
