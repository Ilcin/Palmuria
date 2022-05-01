using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideWhilePlaying : MonoBehaviour {

	void Start () {
		MeshRenderer[] meshRenderers = GetComponents<MeshRenderer> ();
		for (int i = 0; i < meshRenderers.Length; i++) {
			meshRenderers [i].enabled = false;
		}
		SpriteRenderer[] spriteRenderers = GetComponents<SpriteRenderer> ();
		for (int i = 0; i < spriteRenderers.Length; i++) {
			spriteRenderers [i].enabled = false;
		}
		if (meshRenderers.Length + spriteRenderers.Length < 1)
			Debug.LogWarning ("Couldn't find render components to hide", this);
	}
}
