using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SmallMenu : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private Transform menuPanel;
    [SerializeField] private Transform btnPanel;

    private MenuAction _inputActions;
    private bool _isOpen;

    private void Start()
    {
        _inputActions = new MenuAction();
        _inputActions.Enable();
        _isOpen = false;

        _inputActions.Menu.OpenClose.performed += perf => OpenCloseMenu();
    }

    public void OpenCloseMenu()
    {
        if (_isOpen)
        {
            foreach (Transform child in menuPanel)
            {
                if (child != btnPanel)
                    ClosePanel(child.gameObject);
            }

            movement.SetIsMove(true);
            ClosePanel(menuPanel.gameObject);
            ChangeIsOpen(false);
        } else
        {
            movement.SetIsMove(false);
            OpenPanel(menuPanel.gameObject);
            ChangeIsOpen(true);
        }
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void ChangeIsOpen(bool value)
    {
        _isOpen = value;
    }

    public bool GetIsOpen()
    {
        return _isOpen;
    }

    public void RestartLevel(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
