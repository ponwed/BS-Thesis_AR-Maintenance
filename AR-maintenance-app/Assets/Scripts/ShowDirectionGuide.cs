using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDirectionGuide : MonoBehaviour
{

    public GameObject directionObject;

    private DirectionGuide directionGuide;
    private float screenWidth, screenHeight;
    private float screenFraction = 5;
    private Camera cam;

    /// <summary>
    /// Initialization of the instance.
    /// </summary>
    void Start()
    {
        directionGuide = directionObject.GetComponent<DirectionGuide>();

        cam = Camera.main;
        screenHeight = Screen.height;
        screenWidth = Screen.width;
    }

    /// <summary>
    /// Runs once every frame
    /// </summary>
    void Update()
    {
        if (GetComponent<Renderer>().enabled)
        {
            Vector3 screenPos = cam.WorldToScreenPoint(transform.position);
            directionGuide.SetTarget(transform);

            float heightMargin = screenHeight / screenFraction;
            float widthMargin = screenWidth / screenFraction;

            if (screenPos.y > heightMargin && screenPos.y < screenHeight - heightMargin && screenPos.x > widthMargin && screenPos.x < screenWidth - widthMargin)
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
