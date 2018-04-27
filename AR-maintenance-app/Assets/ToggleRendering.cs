using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleRendering : MonoBehaviour {

    public ViewState viewState;
    public int stepIndex;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(viewState.GetState());
        if (viewState.GetState() == stepIndex)
        {
            foreach (var r in GetComponentsInChildren<Renderer>())
            {
                r.enabled = true;
            }
        }
        else
        {
            foreach (var r in GetComponentsInChildren<Renderer>())
            {
                r.enabled = false;
            }
        }
	}
}
