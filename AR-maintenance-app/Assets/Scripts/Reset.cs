using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour {

    public ViewState viewState;

    private Button btn;

    /// <summary>
    /// Initialization of the instance.
    /// </summary>
    void Start () {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(ExitApp);

        Hide();
    }

    /// <summary>
    /// Runs once every frame
    /// </summary>
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

    /// <summary>
    /// Close the application
    /// </summary>
    void ExitApp()
    {
        Application.Quit();
    }

    /// <summary>
    /// Hide the GUI elements
    /// </summary>
    void Hide()
    {
        btn.GetComponent<Image>().enabled = false;
        btn.GetComponent<Button>().enabled = false;
        btn.GetComponentInChildren<Text>().enabled = false;
    }

    /// <summary>
    /// Show the GUI elements
    /// </summary>
    void Show()
    {
        btn.GetComponent<Image>().enabled = true;
        btn.GetComponent<Button>().enabled = true;
        btn.GetComponentInChildren<Text>().enabled = true;
    }
}
