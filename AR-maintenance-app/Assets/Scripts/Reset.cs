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
        btn.onClick.AddListener(ExitApp);

        Hide();
    }

    void Update()
    {
        if(viewState.AtLastState())
        {
            Show();
        } else
        {
            Hide();
        }
    }
    void ExitApp()
    {
        Application.Quit();
    }

    void Hide()
    {
        btn.GetComponent<Image>().enabled = false;
        btn.GetComponent<Button>().enabled = false;
        btn.GetComponentInChildren<Text>().enabled = false;
    }

    void Show()
    {
        btn.GetComponent<Image>().enabled = true;
        btn.GetComponent<Button>().enabled = true;
        btn.GetComponentInChildren<Text>().enabled = true;
    }
}
