using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class CollectionItemUIBtn : MonoBehaviour
{
    [SerializeField] private CollectionUIManagerPanel collectionPanel;
    private Button _btn;
    private int _num;

    private void Start()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(OpenPanel);
    }

    private void OpenPanel()
    {

    }

    public void SetNum(int value)
    {
        _num = value;
    }
}
