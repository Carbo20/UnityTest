using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PanelDescManager : MonoBehaviour {

    private bool isExpand;
    private RectTransform rectTransform;
    private Toggle toggle;
	// Use this for initialization
	void Start () {
        Toggle.ToggleEvent toggleEvent;
        isExpand = false;
        rectTransform = GetComponent<RectTransform>();
        toggle = GetComponent<Toggle>();
        toggleEvent = new Toggle.ToggleEvent();
        toggleEvent.AddListener(PanelPushed);
        toggle.onValueChanged = toggleEvent;
    }
	
	// Update is called once per frame
	void Update () {
        if (!isExpand)
        {
            if (rectTransform.offsetMax.y != -430 && rectTransform.offsetMin.y != -220)
            {
                Debug.Log("hide");
                rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, -430);
                rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x, -220);
            }
        }
        else
        {

            if (rectTransform.offsetMax.y != -212 && rectTransform.offsetMin.y != -2)
            {
                Debug.Log("expand");
                rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, -212);
                rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x, -2);
            }
        }
	}

    public void PanelPushed(bool b)
    {
        isExpand = !isExpand;
    }
}
