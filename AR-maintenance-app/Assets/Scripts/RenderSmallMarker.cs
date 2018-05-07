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

    /// <summary>
    /// Initialization of the instance.
    /// </summary>
    void Start()
    {
        marker = tracker.transform;
        ToggleSprites(false);
    }

    /// <summary>
    /// Runs once every frame
    /// </summary>
    void Update()
    {
        // If step should be visible, start looking if sleigh marker is active
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

    /// <summary>
    /// Toggles sprite renderer on or off.
    /// </summary>
    /// <param name="b">If sprite should render or not.</param>
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

    /// <summary>
    /// Toggles mesh renderer on or off.
    /// </summary>
    /// <param name="b">If sprite should render or not.</param>
    private void ToggleRenderer(bool render)
    {
        if (indicator == null)
            return;

        foreach (var r in indicator.GetComponentsInChildren<Renderer>())
        {
            r.enabled = render;
        }
    }

    /// <summary>
    /// Set if a child should render or not.
    /// </summary>
    /// <param name="render">If child should render.</param>
    public void Render(bool render)
    {
        visible = render;
    }
}
