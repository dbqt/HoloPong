using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour {

    public UnityEvent EventCallbackSelect;
    public UnityEvent EventCallbackEnter;
    public UnityEvent EventCallbackExit;

	public void GazeEntered()
    {
        EventCallbackEnter.Invoke();
    }

    public void GazeExited()
    {
        EventCallbackExit.Invoke();
    }

    public void OnSelect()
    {
        EventCallbackSelect.Invoke();
    }
}
