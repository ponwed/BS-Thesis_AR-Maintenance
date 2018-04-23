using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.Linq;

public class RenderSmallMarker : MonoBehaviour {

    public ViewState viewState;
    public GameObject tracker;
    public GameObject indicator;
    private Transform marker;
    private bool visible;

    void Start()
    {
        marker = tracker.transform;
        ToggleSprites(false);
    }

    void Update()
    {
        /* If step should be visible, start looking if sleigh marker is active */
        if (visible)
        {
            StateManager sm;
            IEnumerable<TrackableBehaviour> trackables;

            sm = TrackerManager.Instance.GetStateManager();
            trackables = sm.GetActiveTrackableBehaviours();
            
            if (trackables.FirstOrDefault(GameObject => GameObject.name == tracker.name))
            {
                ToggleRenderer(false);
                ToggleSprites(visible);
            }
            else
            {
                ToggleRenderer(true);
                ToggleSprites(false);
            }        
        }
        else

        {
            ToggleSprites(false);
        }
    }

    private void ToggleSprites(bool b)
    {
        for (int i = 0; i < marker.childCount; i++)
        {
            if (marker.GetChild(i).childCount == 0)
                marker.GetChild(i).GetComponent<Renderer>().enabled = b;
            else
                marker.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().enabled = b;
        }
    }

    private void ToggleRenderer(bool render)
    {
        foreach (var r in indicator.GetComponentsInChildren<Renderer>())
        {
            r.enabled = render;
        }
    }

    public void Render(bool render)
    {
        visible = render;
    }
}
