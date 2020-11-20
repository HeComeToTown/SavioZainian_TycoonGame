using UnityEngine;

public class SalesCalculator
{
    /// <summary>
    /// This class is used for calculation the amount of products sold on any given day.
    /// </summary>

    float price;
    float invest;
    float trendScaler;
    float priceScaler;
    float investmentScaler;
    float interestFallOffScaler;
    float qualityMagnitude;

    public float Quality { get; set; }
    public float PriceOfProduct { get => price; set => price = value; }

    public float PriceInvested { get => invest; set => invest = value; }

    public float MagnitudeOfQuality { get => qualityMagnitude; set => value = 1; }

    public float TrendScaler { get => trendScaler; set => value = 1; }
    public float PriceToPurchaseRateScaler { get => priceScaler; set => value = 1; }
    public float InvestmentScaler { get => investmentScaler; set => value = 1; }
    public float InterestFallOffScaler { get => interestFallOffScaler; set => value = 1; }

    public float CopiesSoldByDayX(float xDaysSinceRelease)
    {
        float result = 1;
        result *= Mathf.Clamp(Mathf.Lerp(1, TrendFunction(xDaysSinceRelease), 1), 0f, 1f);

        result *= Mathf.Clamp(Mathf.Lerp(1, PriceToPurchase(Quality, PriceOfProduct), 1), 0f, 1f);

        result *= Mathf.Clamp(Mathf.Lerp(1, Investment(PriceInvested), 1), 0f, 1f);

        result *= Mathf.Clamp(Mathf.Lerp(1, InterestFalloff(xDaysSinceRelease, Quality, MagnitudeOfQuality), 1), 0f, 1f);

        return result;
    }


    public override string ToString()
    {
        return "SalesCalculator(" + Quality + ", " + PriceOfProduct + ", " + PriceInvested + ", " + MagnitudeOfQuality + ")";
    }

    private float TrendFunction(float xDays)
    {
        int a = 5;
        int b = 20;
        int c = 50;

        float trendValue = Mathf.Sin(xDays / a) + Mathf.Sin(xDays / b) + Mathf.Sin(xDays / c) + 1;
       
        return trendValue;

        //Math Function: 
        //Trend(g, x) = sin(x / a) + sin(x / b) + sin(x / c) + 1 
    }


    private float PriceToPurchase(float q, float p)
    {
        float priceOfProduct = ((-1) * (Mathf.Sqrt(p * 0.2f)) + Mathf.Pow((1 + q), 2));

        return priceOfProduct;
        //Math Function: 
        //Price(p, q) = -sqrt(p * 0.2) + (1 + q) ^ 2
    }


    private float Investment(float investment)
    {

        return ((-1) * (1 / investment) + 1);


        //Math Function: 
        //A(i) = -1/i +1
    }

    private float InterestFalloff(float xDays, float q, float m)
    {
        float interestFallOff = (100 / xDays) + (q * m);

        return interestFallOff;
        // Math Function: 
        // InterestFalloff(x) = 100/x + q*m
        // m is the magnitue of the quality
    }
}