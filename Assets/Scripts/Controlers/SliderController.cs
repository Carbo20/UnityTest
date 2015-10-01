using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderController : MonoBehaviour {

    private Slider slider;
    private bool valueChanging;
    private int targetValue;
    private float speed;

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
        slider.wholeNumbers = false;
        valueChanging = false;
        speed = 8f;
	}
	
	// Update is called once per frame
	void Update () {
        if (valueChanging)
        {
            if (slider.value > targetValue)
            {
                if (slider.value - speed * Time.deltaTime < targetValue)
                {
                    slider.value = targetValue;
                    valueChanging = false;
                }
                else
                    slider.value -= speed * Time.deltaTime;
            }
            else if (slider.value < targetValue)
            {
                if (slider.value + speed * Time.deltaTime > targetValue)
                {
                    slider.value = targetValue;
                    valueChanging = false;
                }
                else
                    slider.value += speed * Time.deltaTime;
            }
            else
            {
                valueChanging = false;
            }
        }
	}

    public void SetMaxValue(int value)
    {
        slider.maxValue = value;
    }

    public void SetMinValue(int value)
    {
        slider.minValue = value;
    }

    public void SetValue(int value)
    {
        targetValue = value;
        valueChanging = true;
    }

    public void SetBrutValue(int value)
    {
        slider.value = value;
    }
}
