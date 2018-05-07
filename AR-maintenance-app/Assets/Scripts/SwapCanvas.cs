using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwapCanvas : MonoBehaviour {

    public Canvas fromCanvas, toCanvas;

    /// <summary>
    /// Initialization of the instance.
    /// </summary>
    void Start () {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(Swap);
	}
	
    /// <summary>
    /// Swap which canvas to render.
    /// </summary>
	void Swap()
    {
        fromCanvas.enabled = false;
        toCanvas.enabled = true;
    }
}
