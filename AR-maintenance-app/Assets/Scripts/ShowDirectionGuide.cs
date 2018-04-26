using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDirectionGuide : MonoBehaviour
{

    public GameObject directionObject;
    private DirectionGuide directionGuide;
    private float screenWidth, screenHeight;
    private Camera cam;

    void Start()
    {
        directionGuide = directionObject.GetComponent<DirectionGuide>();

        cam = Camera.main;
        screenHeight = Screen.height;
        screenWidth = Screen.width;
    }

    void Update()
    {
        if (GetComponent<Renderer>().enabled)
        {
            Vector3 screenPos = cam.WorldToScreenPoint(transform.position);
            directionGuide.SetTarget(transform);

            if (screenPos.y > 0 && screenPos.y < screenHeight && screenPos.x > 0 && screenPos.x < screenWidth)
            {
                directionGuide.Hide();
            }
            else
            {
                directionGuide.Show();
            }

        }

    }
}
