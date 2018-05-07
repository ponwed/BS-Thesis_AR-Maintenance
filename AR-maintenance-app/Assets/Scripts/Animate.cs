using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Axis {
    X,
    NegX,
    Y,
    NegY,
    Z,
    NegZ
}

public class Animate : MonoBehaviour {

    public Axis axis;
    public float distance = 1.0f;
    public int easeInFactor = 2;
    public float speed = 0.01f;

    private Vector3 origin;
    private float deltaPosition;

    /// <summary>
    /// Initialization of the instance.
    /// </summary>
	void Start () {
        origin = transform.position;
        deltaPosition = 0.0f;
	}

    /// <summary>
    /// Runs once every frame
    /// </summary>
    void Update () {
        var x = origin.x;
        var y = origin.y;
        var z = origin.z;

        float moveDistance = distance * Mathf.Pow(deltaPosition, easeInFactor);

        // Scales moving distance by object scale and add distance to chosen axis
        switch(axis)
        {
            case Axis.X:
                x += moveDistance * transform.localScale.x / 100.0f;
                break;
            case Axis.Y:
                y += moveDistance * transform.localScale.y / 100.0f;
                break;
            case Axis.Z:
                z += moveDistance * transform.localScale.z / 100.0f;
                break;
            case Axis.NegX:
                x -= moveDistance * transform.localScale.x / 100.0f;
                break;
            case Axis.NegY:
                y -= moveDistance * transform.localScale.y / 100.0f;
                break;
            case Axis.NegZ:
                z -= moveDistance * transform.localScale.z / 100.0f;
                break;
        }

        transform.position = new Vector3(x, y, z);
        deltaPosition += speed;
        if (deltaPosition > 1.0f) deltaPosition = 0.0f;
	}
}
