using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.Linq;

public class RenderControl : MonoBehaviour {

    private StateManager sm;
    private IEnumerable<TrackableBehaviour> trackables;
    private Renderer centerCubeRend;

    void Start ()
    {
        centerCubeRend = GameObject.Find("CenterCube").GetComponent<Renderer>();
    }
	
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
