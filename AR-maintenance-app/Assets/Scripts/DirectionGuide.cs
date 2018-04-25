using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionGuide : MonoBehaviour {

    private Transform target;

	void Start () {
        
	}

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

    public void Show()
    {
        GetComponent<Renderer>().enabled = true;

        foreach (var r in GetComponentsInChildren<Renderer>())
        {
            r.enabled = true;
        }
    }

    public void Hide()
    {
        GetComponent<Renderer>().enabled = false;

        foreach (var r in GetComponentsInChildren<Renderer>())
        {
            r.enabled = false;
        }
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
