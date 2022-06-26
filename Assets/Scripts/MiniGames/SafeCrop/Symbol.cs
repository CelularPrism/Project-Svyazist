using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Symbol : MonoBehaviour
{
    [SerializeField] private SaveCrop _saveCrop;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private string _symbolString;
    [SerializeField] private int _symbolNumber;

    public string SymbolString
    {
        get { return _symbolString; }
    }
    public int SymbolNumber
    {
        get { return _symbolNumber; }
    }

    public void ReadValue(string input)
    {
        if (SymbolString == input)
        {
            _saveCrop.PasswordCount++;
            Debug.Log("Correct " + _saveCrop.PasswordCount);

            _inputField.enabled = false;
        }
    }
}
