using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwapCanvas : MonoBehaviour {

    public Canvas fromCanvas, toCanvas;

	void Start () {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(Swap);
	}
	
	void Swap()
    {
        fromCanvas.enabled = false;
        toCanvas.enabled = true;
    }
}
