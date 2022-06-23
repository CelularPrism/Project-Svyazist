using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private MorzeController _morzeController;
    [SerializeField] private bool _canTrigger = true;
    
    private MiniGamesAction _inputActions;

    public bool CanTrigger
    {
        get { return _canTrigger; }
        set { _canTrigger = value;  }
    }

    private void OnEnable()
    {
        _inputActions = new MiniGamesAction();
        _inputActions.MiniGames.Enable();

        _inputActions.MiniGames.MorzeButton.started += perf => _canTrigger = false;
        _inputActions.MiniGames.MorzeButton.canceled += perf => _canTrigger = true;

        _canTrigger = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_canTrigger)
        {
            Debug.Log("Trigger");
            _morzeController.ResultMatch(false, "Miss symbol");
            _morzeController.WrongSound();
        }
    }

    private void OnDisable()
    {
        _inputActions.MiniGames.Disable();
    }
}
