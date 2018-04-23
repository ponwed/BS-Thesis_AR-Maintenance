using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour {

    private Button btn;

	void Start () {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(ExitApp);       
	}

    void ExitApp()
    {
        Application.Quit();
    }
}
