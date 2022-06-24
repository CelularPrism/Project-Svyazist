using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

class SceneManage : MonoBehaviour
{
    [Header("Scene MainMenu")]
    [SerializeField] private int mainMenu;

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
