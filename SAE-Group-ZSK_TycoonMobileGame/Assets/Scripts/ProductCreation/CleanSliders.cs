using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleanSliders : MonoBehaviour
{
    /// <summary>
    /// This script is for the sliders of the investment sectors.
    /// This handles the sliders' colour changing, 
    /// each slider moving back (can't have max of every investment sectors)
    /// </summary>
    [SerializeField] private Slider[] _sliders;

    float maxResources = 350f;

   

    private void Start()
    {
        foreach (var slider in _sliders)
        {
            slider.onValueChanged.AddListener(UpdateSliders);
        }
    }

    private void _createProduct_NewProduct()
    {
        throw new NotImplementedException();
    }

    private void UpdateSliders(float arg0)
    {
        float sum = 0;

        foreach (var slider in _sliders)
        {
            sum += slider.value;
        }

        if(sum > maxResources)
        {
            float multiplyer = maxResources / sum;

            foreach (var slider in _sliders)
            {
                slider.SetValueWithoutNotify(slider.value * multiplyer);
            }
        }

        foreach (var slider in _sliders)
        {
            var image = slider.transform.GetChild(0).GetComponent<Image>();
            image.color = slider.value < 33 ? Color.red : slider.value < 66 ? Color.yellow : Color.green;
        }
    }

    //Changed the colour to red on each new product investment sectors being chosen
    void OnEnable()
    {
        for (int i = 0; i < _sliders.Length; i++)
        {
            _sliders[i].value = 0;
            var image = _sliders[i].transform.GetChild(0).GetComponent<Image>();
            image.color = Color.red;
        }
    }
}
