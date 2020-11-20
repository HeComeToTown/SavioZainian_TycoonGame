using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplaySetup : MonoBehaviour
{
    /// <summary>
    /// This script is used by a prefab that will display on the canvas the product's info
    /// </summary>
   
    [SerializeField] TextMeshProUGUI _name;
    [SerializeField] TextMeshProUGUI _genre;
    [SerializeField] TextMeshProUGUI _price;

    private Product _productInfo;

    void Awake()
    {
        _productInfo = GetComponent<Product>();
    }

    void Start()
    {
        _name.SetText(_productInfo.Name);
        _genre.SetText(_productInfo.Genre.ToString());
        _price.SetText(_productInfo.Price.ToString());
    }
}
