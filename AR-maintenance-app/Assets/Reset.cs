using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour {

    private Button btn;
    public ViewState viewState;

	void Start () {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(ResetInstructions);       
	}

    void ResetInstructions()
    {
        Application.Quit();
        //viewState.Initialize();
    }
}
