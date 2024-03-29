﻿using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour {

    public ViewState state;
    public bool isNext;

    private Button btn;

    /// <summary>
    /// Initialization of the instance.
    /// </summary>
    void Start () {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(() => ActionClick());
    }
	
	/// <summary>
    /// Runs every frame
    /// </summary>
	void Update () {
        ToggleInteractable();
    }

    /// <summary>
    /// Change state
    /// </summary>
    void ActionClick()
    {
        if (isNext)
            state.Next();
        else
            state.Previous();
    }

    /// <summary>
    /// Toggle whether button should be interactable or not.
    /// </summary>
    void ToggleInteractable()
    {
        if (isNext)
            if(state.AtLastState())
                btn.interactable = false;
            else
                btn.interactable = true;
        else
            if (state.AtFirstState())
                btn.interactable = false;
            else
                btn.interactable = true;
    }
}
