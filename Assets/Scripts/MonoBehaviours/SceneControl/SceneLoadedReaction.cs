using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoadedReaction : MonoBehaviour {

	public ReactionCollection reactionCollection;

	private SceneController sceneController;    // Reference to the SceneController so that this can subscribe to events that happen before and after scene loads.


	private void Awake()
	{
		// Find the SceneController and store a reference to it.
		sceneController = FindObjectOfType<SceneController>();

		// If the SceneController couldn't be found throw an exception so it can be added.
		if(!sceneController)
			throw new UnityException("Scene Controller could not be found, ensure that it exists in the Persistent scene.");
	}


	private void Start()
	{
		reactionCollection.React ();
	}
}
