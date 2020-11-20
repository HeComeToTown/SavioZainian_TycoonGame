using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClose : MonoBehaviour
{
    /// <summary>
    /// Script for handeling the tabs between certain UI elemebts
    /// </summary>
    [SerializeField] private GameObject[] _open;
    [SerializeField] private GameObject[] _close;

    [SerializeField] private GameObject _tab;
    
    private GameObject _playerStats;

    void Awake()
    {
        _playerStats = GameObject.FindGameObjectWithTag("PlayerStats");
    }

    public void Open()
    {
        for (int i = 0; i < _open.Length; i++)
        {
            if (!_open[i].activeSelf)
            {
                _open[i].SetActive(true);
            }
        }
    }

    public void Close()
    {
        for (int i = 0; i < _close.Length; i++)
        {
            if (_close[i].activeSelf)
            {
                _close[i].SetActive(false);
            }
        }
    }

    public void HidePlayerStats()
    {
        if (_playerStats == null)
        {
            _playerStats = GameObject.FindGameObjectWithTag("PlayerStats");
        }
        _playerStats.SetActive(false);
    }

    public void ShowPlayerStats()
    {
        if (_playerStats == null)
        {
            _playerStats = GameObject.FindGameObjectWithTag("PlayerStats");
        }
        _playerStats.SetActive(true);
    }

    public void Tab()
    {
        _tab.SetActive(!_tab.active);
    }
}