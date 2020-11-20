using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class AttributeSet : MonoBehaviour
{
    /// <summary>
    /// This script is used for the product's investment sectors.
    /// </summary>
   
    [SerializeField] private ProductsHolder _list;
    [SerializeField] private GameObject _panel;
    [SerializeField] private Slider[] _sliders;
    [SerializeField] private GameObject _playerStats;
    [SerializeField] private RectTransform _addButton;

    public bool AttributesAreNowSet = false;
    public float qualityFromAttributes = 0;

    //Sets the products values to the sliders' values
    public void AttributesAreSet()
    {
        GameObject product = _list.Products[_list.Products.Count - 1];
        Product productInfo = product.GetComponent<Product>();


        productInfo.GamePlay = _sliders[0].value;
        productInfo.Graphics = _sliders[1].value;
        productInfo.Dialogue = _sliders[2].value;
        productInfo.GameDesign = _sliders[3].value;
        productInfo.Ai = _sliders[4].value;
        productInfo.Audio = _sliders[5].value;
        productInfo.WorldDesign = _sliders[6].value;

        product.SetActive(true);

        CalculateQuality(productInfo);

        AttributesAreNowSet = true;

        _playerStats.SetActive(true);
        _panel.SetActive(false);
    }

    //Calculates the quality of the products based off of the player's choises on the investment sectors.
    public void CalculateQuality(Product product)
    {


        float[] playerAttributes = new float[7] { product.GamePlay, product.Graphics, product.Dialogue, product.GameDesign, product.Ai, product.Audio, product.WorldDesign };


        //A preditermend set of attributes that makes a specific genre have a good quality

        float[] goodAdventureAttributes = new float[7] { 25f, 30f, 60f, 80f, 40f, 10f, 40f };

        float[] goodFPSAttributes = new float[7] { 80f, 60f, 10f, 40f, 30f, 70f, 30f };

        float[] goodHorrorAttributes = new float[7] { 40f, 50f, 70f, 75f, 10f, 75f, 50f };

        float[] goodPlatformerAttributes = new float[7] { 50f, 60f, 40f, 50f, 65f, 50f, 70f };

        float[] goodRPGAttributes = new float[7] { 80f, 60f, 90f, 80f, 60f, 50f, 70f };

        float[] goodSimulationAttributes = new float[7] { 60f, 50f, 70f, 80f, 99f, 60f, 50f };

        float[] goodSportsAttributes = new float[7] { 90f, 70f, 50f, 70f, 60f, 50f, 30f };


        qualityFromAttributes = 0;

        switch (product.Genre)
        {

            case Product.EGenre.Adventure:
                qualityFromAttributes = CalculateQualityFuntion(goodAdventureAttributes, playerAttributes);
                break;

            case Product.EGenre.FPS:
                qualityFromAttributes = CalculateQualityFuntion(goodFPSAttributes, playerAttributes);

                break;

            case Product.EGenre.Horror:
                qualityFromAttributes = CalculateQualityFuntion(goodHorrorAttributes, playerAttributes);

                break;

            case Product.EGenre.Platformer:
                qualityFromAttributes = CalculateQualityFuntion(goodPlatformerAttributes, playerAttributes);

                break;

            case Product.EGenre.RPG:
                qualityFromAttributes = CalculateQualityFuntion(goodRPGAttributes, playerAttributes);

                break;

            case Product.EGenre.Simulation:
                qualityFromAttributes = CalculateQualityFuntion(goodSimulationAttributes, playerAttributes);

                break;

            case Product.EGenre.Sports:
                qualityFromAttributes = CalculateQualityFuntion(goodSportsAttributes, playerAttributes);

                break;

            default:
                break;
        }


        product.QualityOfTheProduct = qualityFromAttributes;
    }

    //Actual calculation of the quality
    private float CalculateQualityFuntion(float[] goodAttributes, float[] playerAttributes)
    {
        qualityFromAttributes = 1;

        for (int i = 0; i < playerAttributes.Length; i++)
        {
            if (playerAttributes[i] < goodAttributes[i])
            {
                qualityFromAttributes -= 0.14f;
            }
        }

        return qualityFromAttributes;

    }

    void OnEnable()
    {
        AttributesAreNowSet = false;
    }

    void OnDisable()
    {
        if (!AttributesAreNowSet)
        {
            _list.Products.Remove(_list.Products[_list.Products.Count - 1]);

            UnityEngine.Debug.Log(_list.Products.Count);

            if (_list.Products.Count > 0)
            {
                _addButton.localPosition = new Vector3(-595, _list.Products[_list.Products.Count - 1].GetComponentInChildren<RectTransform>().localPosition.y - 300, 0);
            }
            else
            {
                _addButton.localPosition = new Vector3(-595, 380, 0);
            }
        }
    }
}
