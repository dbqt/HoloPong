﻿using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class GazeGestureManager : MonoBehaviour
{
	public static GazeGestureManager Instance { get; private set; }

	// Represents the hologram that is currently being gazed at.
	public GameObject FocusedObject { get; private set; }

	public Pong pong;

	GestureRecognizer recognizer;

	// Use this for initialization
	void Awake()
	{
		Instance = this;

		// Set up a GestureRecognizer to detect Select gestures.
		recognizer = new GestureRecognizer();
		recognizer.TappedEvent += (source, tapCount, ray) =>
		{
			Debug.Log("Tap");
			// Send an OnSelect message to the focused object and its ancestors.
			if (FocusedObject != null)
			{
				FocusedObject.GetComponent<InteractableObject>().OnSelect();
			}
			else {
				
			pong.StartGame();
			}
		};
		recognizer.StartCapturingGestures();
	}

	// Update is called once per frame
	void Update()
	{
		// Figure out which hologram is focused this frame.
		GameObject oldFocusObject = FocusedObject;

		// Do a raycast into the world based on the user's
		// head position and orientation.
		var headPosition = Camera.main.transform.position;
		var gazeDirection = Camera.main.transform.forward;

		RaycastHit hitInfo;
		if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
		{
			// If the raycast hit a hologram, use that as the focused object.
			InteractableObject io = hitInfo.collider.gameObject.GetComponent<InteractableObject>();
			if (io != null) {
				FocusedObject = hitInfo.collider.gameObject;
			}
		}
		else
		{
			// If the raycast did not hit a hologram, clear the focused object.
			FocusedObject = null;
		}

		// If the focused object changed this frame,
		// start detecting fresh gestures again.
		if (FocusedObject != oldFocusObject)
		{
			if(oldFocusObject != null) oldFocusObject.GetComponent<InteractableObject>().GazeExited();
			if(FocusedObject != null) FocusedObject.GetComponent<InteractableObject>().GazeEntered();
			recognizer.CancelGestures();
			recognizer.StartCapturingGestures();
		}
	}
}