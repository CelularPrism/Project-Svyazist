using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SmallMenuTextStyle : MonoBehaviour
{
    [Header("Change Style Text for TMP")]
    [SerializeField] private Color enableColor;
    [SerializeField] private Color disableColor;

    public void EnableTMPTextStyle(TextMeshProUGUI textField)
    {
        textField.fontStyle = FontStyles.Underline;
        textField.color = enableColor;
    }

    public void DisableTMPTextStyle(TextMeshProUGUI textField)
    {
        textField.fontStyle = FontStyles.Normal;
        textField.color = disableColor;
    }
}
