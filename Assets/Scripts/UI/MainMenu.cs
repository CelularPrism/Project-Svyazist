using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _smallSettingsMenu;
    [SerializeField] private GameObject _nameOfGame;

    [SerializeField] private int _buildIndex;

    private void Start()
    {
        _smallSettingsMenu.SetActive(false);
        _nameOfGame.SetActive(true);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(_buildIndex);
    }
    public void OpenSettingMenu()
    {
        _nameOfGame.SetActive(false);
        _smallSettingsMenu.SetActive(true);
    }
    public void CloseSettingMenu()
    {
        _nameOfGame.SetActive(true);
        _smallSettingsMenu.SetActive(false);
    }
    public void CloseGame()
    {
        Debug.Log("Exit game");
        Application.Quit();
    }
}
