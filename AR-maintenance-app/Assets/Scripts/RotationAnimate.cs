using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RotationDirection
{
    Right,
    Left,
    Up,
    Down,
    Forward,
    Back
}

public class RotationAnimate : MonoBehaviour {

    public RotationDirection direction;
    public float rotateDegrees;
    public float speed;
    public int easeInFactor = 2;

    private Vector3 rotationAxis;
    private float deltaDegree;
    private float rotate;

    // Use this for initialization
    void Start () {
        deltaDegree = 0.0f;
        rotate = 0.0f;

		switch(direction)
        {
            case RotationDirection.Left:
                rotationAxis = Vector3.left;
                break;
            case RotationDirection.Right:
                rotationAxis = Vector3.right;
                break;
            case RotationDirection.Up:
                rotationAxis = Vector3.up;
                break;
            case RotationDirection.Down:
                rotationAxis = Vector3.down;
                break;
            case RotationDirection.Forward:
                rotationAxis = Vector3.forward;
                break;
            case RotationDirection.Back:
                rotationAxis = Vector3.back;
                break;

        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotationAxis, -rotate);
        rotate = rotateDegrees * Mathf.Pow(deltaDegree, easeInFactor);
        deltaDegree += speed;
        transform.Rotate(rotationAxis, rotate);
        if (deltaDegree > 1.0f) deltaDegree = 0.0f;
    }

}
