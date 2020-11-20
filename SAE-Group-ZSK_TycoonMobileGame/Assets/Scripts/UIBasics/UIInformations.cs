using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class UIInformations : MonoBehaviour
{
    /// <summary>
    /// Script for setting certain UI elements active
    /// </summary>
   
    public TextMeshProUGUI InfoTextField;
    [SerializeField] private GameObject infoTextObj;

    void Start()
    {
        infoTextObj.SetActive(false);
    }


    public void ShowHint(string info)
    {
        infoTextObj.SetActive(true);
        InfoTextField.text = info;
        StartCoroutine(ShowTextShort());
    }

    IEnumerator ShowTextShort() 
    {
        yield return new WaitForSeconds(1f);
        infoTextObj.SetActive(false);
    }
}
