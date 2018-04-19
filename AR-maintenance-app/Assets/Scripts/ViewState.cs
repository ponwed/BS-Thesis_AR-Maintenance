using System;
using System.Collections.Generic;
using UnityEngine;

public class ViewState : MonoBehaviour {
    
    int state;
    int stateCount;
    Transform marker;
    public GameObject tracker; // Passed via Unity GUI
    public RenderStep3 renderStep3;
    public int sleighStepIndex;

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

    public bool AtLastState()
    {
        return state == stateCount - 1;
    }

    public bool AtFirstState()
    {
        return state == 0;
    }

    /// <summary>
    /// Changes what to render based on the state.
    /// </summary>
    void Toggle()
    {
        for(var i = 0; i < stateCount; i++)
        {
            bool visible = i == state;
            var child = marker.GetChild(i);

            foreach (var r in child.GetComponentsInChildren<Renderer>(true))
            {
                r.enabled = visible;
            }           
        }

        /* Special case for sled marker */
        if (state == sleighStepIndex)
            renderStep3.Render(true);
        else
            renderStep3.Render(false);
    }

    public int GetState()
    {
        return state;
    }

}
