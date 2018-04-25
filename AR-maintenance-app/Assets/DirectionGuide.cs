using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionGuide : MonoBehaviour {

    public Transform target;
    private Vector3 pos;
	// Use this for initialization
	void Start () {
        pos = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 up = new Vector3(0, 1, 0);

        transform.LookAt(target, up);

        //Vector3 cameraPos = Camera.main.transform.position;
        //Vector3 dirVector = pos - cameraPos;

        //Debug.Log(dirVector);
	}
}
