using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBehaviour5 : MonoBehaviour {

	public CutsceneController cutsceneController;
	public AudioSource oh;
	public CharacterProps kei;

	private TextManager textManager;

	void Awake() {
		textManager = FindObjectOfType<TextManager> ();
	}

	void FixedUpdate () {
		if (cutsceneController.frameCount == 30) {
			oh.gameObject.SetActive (true);
			textManager.DisplayMessage ("Ohh", kei, 0);
		}
		
		if (cutsceneController.frameCount > 180) {
			textManager.DisplayMessage ("Hier endet die Demo. Vielen Dank fürs Spielen! (Klicken zum Beenden)", null, 0, true);
			if (Input.GetMouseButtonDown (0)) {
				Debug.Log ("Würde schließen");
				Application.Quit ();
			}
		}
	}
}
