using System;
using System.Collections.Generic;
using UnityEngine;

public class ViewState : MonoBehaviour {
    
    int state;
    int stateCount;
    Transform marker;
    public GameObject tracker; // Passed via Unity GUI

    /// <summary>
    /// Initialization of the instance.
    /// </summary>
    void Start () {
        state = 0;
        try
        {
            marker = tracker.transform;
        } catch(Exception e)
        {
            Debug.Log("No Tracker defined.");
            throw e;
        }
        stateCount = marker.childCount;
        Toggle();
        Debug.Log("View state starting ");
    }
	
	/// <summary>
    /// Called every frame.
    /// </summary>
	void Update () {
		
	}

    /// <summary>
    /// Go to next state.
    /// </summary>
    public void Next()
    {
        if (state >= stateCount - 1) return;
        state++;
        Toggle();
        Debug.Log("Next state: " + state);
    }

    /// <summary>
    /// Go to previous state.
    /// </summary>
    public void Previous()
    {
        if (state <= 0) return;
        state--;
        Toggle();
        Debug.Log("Previous state " + state);
    }

    /// <summary>
    /// Changes what to render based on the state.
    /// </summary>
    void Toggle()
    {
        for(var i = 0; i < stateCount; i++)
        {
            bool visible = false;
            var child = marker.GetChild(i);

            if (i == state) visible = true;

            foreach(var r in child.GetComponentsInChildren<Renderer>(true))
            {
                r.enabled = visible;
            }
        }
    }

}
