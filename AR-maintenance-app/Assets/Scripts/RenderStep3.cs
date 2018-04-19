using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.Linq;

public class RenderStep3 : MonoBehaviour {

    public ViewState viewState;
    public GameObject tracker;
    public GameObject indicatorCircle;
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
                //indicatorCircle.GetComponent<Renderer>().enabled = false;
                indicatorCircle.transform.GetComponent<Renderer>().enabled = false;

                for (int i = 0; i < marker.childCount; i++)
                {
                    ToggleSprites(visible);
                }
            }
            else
                indicatorCircle.transform.GetComponent<Renderer>().enabled = true;
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

    public void Render(bool render)
    {
        visible = render;
    }
}
