using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductsHolder : MonoBehaviour
{
    /// <summary>
    /// This script is for a list for all the products (prefabs) created.
    /// </summary>

    [SerializeField] private List<GameObject> _products = new List<GameObject>();

    public List<GameObject> Products { get => _products; private set => _products = value; }
    

    public void AddProduct(GameObject go)
    {
        Products.Add(go);
    }
  
}
