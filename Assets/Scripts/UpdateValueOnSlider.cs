using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpdateValueOnSlider : MonoBehaviour
{
    public Slider slider;
    public Text text; 

    private void OnEnable()
    {
        slider.onValueChanged.AddListener(ChangeValue);
        ChangeValue(slider.value);
    }

    private void OnDisable()
    {
        slider.onValueChanged.RemoveAllListeners();
    }

    private void ChangeValue(float value)
    {
        text.text = value.ToString();
    }
}
