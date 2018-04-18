using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PersistentTracking : MonoBehaviour {

	void Start () {
        VuforiaARController.Instance.RegisterVuforiaStartedCallback(OnVuforiaStarted);
	}

	void OnVuforiaStarted () {
        ObjectTracker tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
        bool success = tracker.PersistExtendedTracking(true);

        Debug.Log("PTracking: " + success);
	}
}
