using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;

    private PlayerAction _inputActions;

    private void Start()
    {
        _inputActions = new PlayerAction();
        _inputActions.Enable();
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }
}
