using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontRender : MonoBehaviour {

	void Start () {
        //gameObject.SetActive(false);
        Renderer rend = GetComponent<Renderer>();
        rend.enabled = false;
	}

}
