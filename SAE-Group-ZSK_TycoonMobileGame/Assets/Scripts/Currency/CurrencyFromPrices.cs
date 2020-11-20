using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyFromPrices : MonoBehaviour
{
    private SalesCalculator _salesCalculator = new SalesCalculator();

    [SerializeField] private CreateProduct _createProduct;
    [SerializeField] private AttributeSet _attributeSet;
    [SerializeField] private CurrencyHandler _currencyHandler;
    [SerializeField] private TimeSystem _timeSystem;
    [SerializeField] private ProductsHolder _productsHolder;
    [SerializeField] private Product _product;
    [SerializeField] private WindowGraph _graph;

    [SerializeField] private TextMeshProUGUI _currencyPerDay;
    [SerializeField] private TextMeshProUGUI _productsSold;
    private int _productsSoldInt;
    private int _thisProductSoldTodayInt;

    private void Start()
    {
        _timeSystem.NewDay += ChangeCurrencyWithProductPrices;
        _currencyPerDay.SetText("{0}/day $", 0f);
    }

    private void ChangeCurrencyWithProductPrices()
    {

        if (_attributeSet.AttributesAreNowSet == true)
        {


            _salesCalculator.Quality = _attributeSet.qualityFromAttributes;
            float xDays = _timeSystem.daysPlayedTotal /*- _product.DayCreated*/;



            for (int i = 0; i <= _createProduct.TotalPrices.Count - 1; i++)
            {
                if (_createProduct.TotalPrices.Count < 0)
                    return;

                _salesCalculator.PriceOfProduct = _createProduct.TotalPrices[i];
                _salesCalculator.PriceInvested = _createProduct.TotalInvested[i];

                float _copiesSold = _salesCalculator.CopiesSoldByDayX(xDays);
                float moneyMadeFromCopies = _createProduct.TotalPrices[i] * _copiesSold;

                _currencyPerDay.SetText(moneyMadeFromCopies.ToString("F", CultureInfo.InvariantCulture) + "/day $" );

                _thisProductSoldTodayInt = Mathf.RoundToInt(_copiesSold);
                _productsSoldInt += _thisProductSoldTodayInt;
                _productsSold.text = _productsSoldInt.ToString();

                Debug.Log(_productsHolder.Products[i].name + ": " + _thisProductSoldTodayInt);

                _graph = _productsHolder.Products[i].GetComponent<WindowGraph>();
                _graph.UpdateGraph(_thisProductSoldTodayInt);

                if (_copiesSold > 0)
                {
                    _currencyHandler.ModifyCurrency(moneyMadeFromCopies);
                }
            }
        }

    }
}
