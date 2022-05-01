using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour {

	public Camera Camera;
	public GameObject Plane;

	private SpriteRenderer spriteRenderer;
	private NavMeshAgent navMeshAgent;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		navMeshAgent = GetComponent<NavMeshAgent> ();
		navMeshAgent.updateRotation = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (navMeshAgent.velocity.magnitude > 0) {
			spriteRenderer.flipX = navMeshAgent.velocity.x < 0;
		}
		if (Input.GetButtonDown ("Fire1")) {
			Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.gameObject == Plane) {
					navMeshAgent.destination = hit.point;
				}
			}
		}
	}
}
