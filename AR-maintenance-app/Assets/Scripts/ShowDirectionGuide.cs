using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDirectionGuide : MonoBehaviour {

    public GameObject directionObject;
    private DirectionGuide directionGuide;
    private bool visible;

	void Start () {
        directionGuide = directionObject.GetComponent<DirectionGuide>();
        visible = false;
    }
	
	void Update () {

        if (GetComponent<Renderer>().enabled)
        {
            directionGuide.SetTarget(transform);
            if (!visible)
            {
                directionGuide.Show();
                visible = !visible;
            }
        }
        else
        {
            visible = false;
        }
    }

    private void OnBecameInvisible()
    {
        if (GetComponent<Renderer>().enabled)
        {
            directionGuide.Show();
            visible = true;
        }  
    }

    private void OnBecameVisible()
    {
        if (GetComponent<Renderer>().enabled)
        {
            directionGuide.Hide();
        }      
    }
}
