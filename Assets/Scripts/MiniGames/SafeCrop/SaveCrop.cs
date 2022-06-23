using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SaveCrop : MonoBehaviour
{
    [SerializeField] private Image _safeOpen;
    [SerializeField] private Image _safeNotOpen;
    [SerializeField] private Animator _handleAnimator;
    [SerializeField] private string prevScene = "DestroedLevelFinal";
    [SerializeField] private string currentScene = "SaveCrap";
    [SerializeField] private string nextScene = "Hill";

    private MiniGamesAction _inputActions;
    private string[] password = { "0", "9", "2", "5"};

    private bool _isFinished = false;
    private int _passwordCount = 0;

    public int PasswordCount
    {
        get { return _passwordCount;  }
        set { _passwordCount = value; }
    }

    private void OnEnable()
    {
        _inputActions = new MiniGamesAction();
        _inputActions.MiniGames.Enable();
        _inputActions.MiniGames.Reback.performed += perf => ReturnPreviousScene(perf);
}

    private void ReturnPreviousScene(InputAction.CallbackContext perf)
    {

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(prevScene));
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(currentScene));
    }
    private void OnDisable()
    {
        _inputActions.MiniGames.Disable();
    }

    private void Update()
    {
        if (_passwordCount >= 4 && !_isFinished)
        {
            _isFinished = true;
            _handleAnimator.SetBool("Handle", _isFinished);
            Invoke("GetNextLevel", 1f);
        }
    }
    private void GetNextLevel()
    {
        SceneManager.LoadScene(nextScene);
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(currentScene));
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(prevScene));

    }
}
