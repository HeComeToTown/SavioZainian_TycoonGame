using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowGraph : MonoBehaviour
{
    [SerializeField] private RectTransform _graphContainer;
    [SerializeField] private Sprite _circle;

    private List<GameObject> _circles = new List<GameObject>();
    private float _graphCeilling = 5;
    private float day;

    private void CreateCircle(Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(_graphContainer, false);
        gameObject.GetComponent<Image>().sprite = _circle;
        gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 100);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(11, 11);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        _circles.Add(gameObject);
    }

    public void UpdateGraph(float yPos)
    {
        if (yPos > _graphCeilling)
        {
            _graphCeilling = yPos * 1.5f;
            for (int i = 0; i < _circles.Count - 1; i++)
            {
                RectTransform rectTransform = _circles[i].GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y / 1.5f);
            }
        }

        if (day <= 248)
        {
            CreateCircle(new Vector2(10 + day * 5, yPos * 100));
        }
        else
        {
            return;
        }
        day += 1;
    }
}
