using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.Linq;

public class RenderControl : MonoBehaviour {

    private StateManager sm;
    private IEnumerable<TrackableBehaviour> trackables;
    private Renderer centerCubeRend;

    /// <summary>
    /// Initialization of the instance.
    /// </summary>
    void Start ()
    {
        centerCubeRend = GameObject.Find("CenterCube").GetComponent<Renderer>();
    }
	
    /// <summary>
    /// Runs once every frame
    /// </summary>
	void Update ()
    {
        sm = TrackerManager.Instance.GetStateManager();
        trackables = sm.GetActiveTrackableBehaviours();

        if (trackables.Any())
            centerCubeRend.enabled = true;
        else
            centerCubeRend.enabled = false;

    }
}
