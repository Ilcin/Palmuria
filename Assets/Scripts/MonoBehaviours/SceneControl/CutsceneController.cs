using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour {
	public int durationInFixedFrames = 10000;
	public int frameCount;
	public string nextSceneName;
	public string startingPositionName;

	private SceneController sceneController;
	private GameObject inventoryUi;

	void Start() {
		sceneController = FindObjectOfType<SceneController> ();
		inventoryUi = GameObject.FindGameObjectWithTag ("Inventory UI");

		frameCount = 0;

		if (!sceneController) {
			Debug.LogWarning ("CutsceneController didn't find SceneController, will not change scene", this);
		}

		if (inventoryUi) {
			inventoryUi.SetActive(false);
		}
	}

	void FixedUpdate() {
		if (frameCount < durationInFixedFrames) {
			frameCount++;
			return;
		}

		if (!sceneController) {
			return;
		}

		if (inventoryUi) {
			inventoryUi.SetActive(true);
		}

		sceneController.FadeAndLoadScene (nextSceneName, startingPositionName);
	}

	IEnumerator WaitForEnd() {
		while (frameCount < durationInFixedFrames) {
			yield return null;
		}
	}
}
