using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reset : MonoBehaviour {

    private Button btn;
    public ViewState viewState;

	void Start () {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(ResetInstructions);       
	}

    void ResetInstructions()
    {
        viewState.Initialize();
    }
}
