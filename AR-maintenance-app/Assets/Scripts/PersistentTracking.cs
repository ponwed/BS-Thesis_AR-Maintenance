using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PersistentTracking : MonoBehaviour {

    public bool persistentTracking;

    /// <summary>
    /// Initialization of the instance.
    /// </summary>
    void Start () {
        VuforiaARController.Instance.RegisterVuforiaStartedCallback(OnVuforiaStarted);
	}

    /// <summary>
    /// Change tracking method to persist extended tracking
    /// </summary>
	void OnVuforiaStarted () {
        ObjectTracker tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
        bool success = tracker.PersistExtendedTracking(persistentTracking);

        Debug.Log("PTracking: " + success);
	}
}
