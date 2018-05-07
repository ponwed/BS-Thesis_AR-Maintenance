using UnityEngine;
using UnityEngine.UI;


public class Caption : MonoBehaviour {

    public Canvas canvas;
    public string captionText;
    public float rightMargin = 160;
    public float height = 160;
    public int minFontSize = 20;
    public int maxFontSize = 52;

    /// <summary>
    /// Initialization of the instance.
    /// </summary>
	void Start () {
        canvas = Instantiate(canvas);
        var panel = canvas.transform.GetChild(0);

        var panelTransform = panel.GetComponent<RectTransform>();

        var width = canvas.GetComponent<RectTransform>().rect.width - rightMargin;
        panelTransform.sizeDelta = new Vector2(width, height);

        var textField = panel.GetChild(0);
        textField.GetComponent<Text>().text = captionText;
        textField.GetComponent<Text>().resizeTextForBestFit = true;
        textField.GetComponent<Text>().resizeTextMinSize = minFontSize;
        textField.GetComponent<Text>().resizeTextMaxSize = maxFontSize;

        canvas.GetComponent<Canvas>().enabled = false;  
	}
	
    /// <summary>
    /// Set whether to show or hide caption
    /// </summary>
    /// <param name="visible">Bool</param>
    public void SetVisibility(bool visible)
    {
        canvas.GetComponent<Canvas>().enabled = visible;
    }

}
