using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptBtnNext : MonoBehaviour {

    private Button myselfButton;
    public ViewState state;
    public bool isNext;

    // Use this for initialization
    void Start () {
        var btn = GetComponent<RectTransform>();
        int size = Screen.width / 2;
        btn.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);
        btn.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size/4);

        myselfButton = GetComponent<Button>();
        myselfButton.onClick.AddListener(() => ActionClick());

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void ActionClick()
    {
        if (isNext)
            state.Next();
        else
            state.Previous();
    }
}
