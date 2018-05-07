using System;
using System.Collections.Generic;
using UnityEngine;

public class ViewState : MonoBehaviour {
    
    int state;
    int stateCount;
    Transform marker;
    public GameObject tracker;
    public RenderSmallMarker renderStep3, renderStep8;
    public int sleighStepIndex, sleighStepIndexTwo;
    public GameObject directionObject;

    /// <summary>
    /// Initialization of the instance.
    /// </summary>
    void Start () {
        Initialize();
    }

    /// <summary>
    /// Registers the number of states in a given marker. 
    /// </summary>
    public void Initialize()
    {
        state = 0;
        try
        {
            marker = tracker.transform;
        }
        catch (Exception e)
        {
            Debug.Log("No Tracker defined.");
            throw e;
        }
        stateCount = marker.childCount;
        Toggle();
        Debug.Log("View state starting ");
    }

    /// <summary>
    /// Go to next state.
    /// </summary>
    public void Next()
    {
        if (state >= stateCount - 1) return;
        state++;
        Toggle();
    }

    /// <summary>
    /// Go to previous state.
    /// </summary>
    public void Previous()
    {
        if (state <= 0) return;
        state--;
        Toggle();
    }

    /// <summary>
    /// Returns whether the current state the last.
    /// </summary>
    /// <returns>True if current state is last, false otherwise.</returns>
    public bool AtLastState()
    {
        return state == stateCount - 1;
    }

    /// <summary>
    /// Returns whether the current state the fist.
    /// </summary>
    /// <returns>True if current state is fist, false otherwise.</returns>
    public bool AtFirstState()
    {
        return state == 0;
    }

    /// <summary>
    /// Changes what to render based on the state.
    /// </summary>
    void Toggle()
    {
        directionObject.GetComponent<DirectionGuide>().Hide();
        for(var i = 0; i < stateCount; i++)
        {
            bool visible = i == state;
            var child = marker.GetChild(i);

            // Show/Hide caption for step
            Caption caption = null;
            if ((caption = child.GetComponent<Caption>()) != null)
            {
                caption.SetVisibility(visible);
            }

            // Set visibility for the respective child
            foreach (var r in child.GetComponentsInChildren<Renderer>(true))
            {
                r.enabled = visible;
            }           
        }

        // Special case for sled marker
        if (state == sleighStepIndex)
            renderStep3.Render(true);
        else if (state == sleighStepIndexTwo)
            renderStep8.Render(true);
        else
        {
            renderStep3.Render(false);
            renderStep8.Render(false);
        }
            
    }

    /// <summary>
    /// Returns the current state.
    /// </summary>
    /// <returns>The current state</returns>
    public int GetState()
    {
        return state;
    }

}
