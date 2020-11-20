using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CleanInputFields : MonoBehaviour
{
    /// <summary>
    /// Script of clearing the values of the input field.
    /// </summary>
    [SerializeField] private TMP_InputField _name;
    [SerializeField] private TMPro.TMP_Dropdown _genre;
    [SerializeField] private TMP_InputField _price;
    [SerializeField] private TMP_InputField _invest;

    void OnDisable()
    {
        _name.text = "";
        _genre.value = 0;
        _price.text = "";
        _invest.text = "";
    }
}
