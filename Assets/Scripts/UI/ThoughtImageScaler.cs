using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtImageScaler : MonoBehaviour
{
    [SerializeField] private Transform textField;

    [Header("Size relationship")]
    [SerializeField] private float height;
    [SerializeField] private float width;

    void Update()
    {
        RectTransform rect = transform.GetComponent<RectTransform>();
        Vector2 sizeText = textField.GetComponent<RectTransform>().sizeDelta;
        rect.sizeDelta = new Vector2(sizeText.x + width, sizeText.y + height);
    }
}
