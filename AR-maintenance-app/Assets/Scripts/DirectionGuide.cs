using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionGuide : MonoBehaviour {

    private Transform target;

    /// <summary>
    /// Initialization of the instance.
    /// </summary>
    void Start () {
        
	}

    /// <summary>
    /// Runs once every frame
    /// </summary>
    void Update () {
        if (target == null)
        {
            Hide();
        }
        else
        {
            transform.LookAt(target);
        }     
	}

    /// <summary>
    /// Show direction guide.
    /// </summary>
    public void Show()
    {
        GetComponent<Renderer>().enabled = true;

        foreach (var r in GetComponentsInChildren<Renderer>())
        {
            r.enabled = true;
        }
    }

    /// <summary>
    /// Hide direction guide.
    /// </summary>
    public void Hide()
    {
        GetComponent<Renderer>().enabled = false;

        foreach (var r in GetComponentsInChildren<Renderer>())
        {
            r.enabled = false;
        }
    }

    /// <summary>
    /// Set target to guide direction to.
    /// </summary>
    /// <param name="target">The target</param>
    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
