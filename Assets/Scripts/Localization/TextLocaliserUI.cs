using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextLocaliserUI : MonoBehaviour
{
    private TextMeshProUGUI textField;
    
    private LocalisationSystem.Language _language;

    public string key;

    private void Start()
    {
        textField = GetComponent<TextMeshProUGUI>();
        _language = LocalisationSystem.GetLanguage();
        string value = LocalisationSystem.GetLocalisedValue(key);
        textField.text = value;
    }

    private void Update()
    {
        LocalisationSystem.Language lang = LocalisationSystem.GetLanguage();
        if (_language != lang)
        {
            _language = lang;
            string value = LocalisationSystem.GetLocalisedValue(key);
            textField.text = value;
        }
    }
}
