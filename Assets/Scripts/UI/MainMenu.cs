using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _nameOfGame;

    [SerializeField] private int _buildIndex = 1;

    private bool _stateOfAddinionalMenu = false;

    private void Start()
    {
        _nameOfGame.SetActive(true);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(_buildIndex);
    }
    public void OpenSettingMenu(GameObject additionalMenu)
    {
        _stateOfAddinionalMenu = !_stateOfAddinionalMenu;
        _nameOfGame.SetActive(!_stateOfAddinionalMenu);
        additionalMenu.SetActive(_stateOfAddinionalMenu);
    }
    public void CloseSettingMenu(GameObject additionalMenu)
    {
        _stateOfAddinionalMenu = !_stateOfAddinionalMenu;

        _nameOfGame.SetActive(!_stateOfAddinionalMenu);
        additionalMenu.SetActive(_stateOfAddinionalMenu);
    }
    public void CloseGame()
    {
        Debug.Log("Exit game");
        Application.Quit();
    }
}
