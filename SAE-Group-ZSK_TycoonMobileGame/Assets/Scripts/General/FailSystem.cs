using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailSystem : MonoBehaviour
{
    /// <summary>
    /// This script is used for when the player fails.
    /// </summary>
    [SerializeField] private CurrencyHandler currencyHandler;
    
    public delegate void ZSK_GameFailed();
    public event ZSK_GameFailed OnGameFailed;

    void Start()
    {
        currencyHandler.OnChangeCurrency += CurrencyFailCheck;
    }

    private void CurrencyFailCheck(float currency)
    {
        if (currency < 0)
        {
            OnGameFailed?.Invoke();
        }
    }
}
