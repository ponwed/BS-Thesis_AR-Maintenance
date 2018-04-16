using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class RenderControl : MonoBehaviour {

    private StateManager sm;
    private IEnumerable<TrackableBehaviour> trackables;

	void Start () {

        trackableBehaviour = GetComponent<TrackableBehaviour>();
        GameObject[] markers = GameObject.FindGameObjectsWithTag("Marker");

        foreach (var marker in markers)
        {
            for (int i = 0; i < marker.transform.childCount; i++)
            {
                marker.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
	
	void Update () {
        sm = TrackerManager.Instance.GetStateManager();
        trackables = sm.GetActiveTrackableBehaviours();

        foreach (var tb in trackables)
        {
            if (tb.name == "MarkerLeft")
            {
                for (int i = 0; i < tb.transform.childCount; i++)
                {
                    tb.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
        }
    }
}
