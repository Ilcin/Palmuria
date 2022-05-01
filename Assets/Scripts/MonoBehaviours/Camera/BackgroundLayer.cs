using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BackgroundLayer : MonoBehaviour {
	
	public Camera camera;
	public SpriteRenderer spriteRenderer;


	void Awake () {
		transform.hideFlags = HideFlags.NotEditable;
	}

	void OnDestroy () {
		transform.hideFlags = HideFlags.None;
	}

	void Update () {
		#if UNITY_EDITOR
		if (!camera) {
			Debug.LogError ("Please set a camera", this);
			return;
		}
		if (!spriteRenderer) {
			Debug.LogError ("Please set the sprite renderer", this);
			return;
		}
		var layerPlane = new Plane (camera.transform.forward, transform.parent.position);
		transform.position = layerPlane.ClosestPointOnPlane (camera.transform.position);
		var distanceToCamera = Vector3.Distance (transform.position, camera.transform.position);
		var unitHeight = 2.0f * distanceToCamera * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
		var scale = unitHeight / (spriteRenderer.sprite.rect.height / spriteRenderer.sprite.pixelsPerUnit);
		transform.localScale = transform.parent.InverseTransformVector (new Vector3 (scale, scale, 1));
		transform.rotation = Quaternion.LookRotation (camera.transform.forward, camera.transform.up);
		#endif
	}
}
