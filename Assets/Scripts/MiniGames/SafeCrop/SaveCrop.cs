using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveCrop : MonoBehaviour
{
    [SerializeField] private Image _safeOpen;
    [SerializeField] private Image _safeNotOpen;
    [SerializeField] private Animator _handleAnimator;

    private string[] password = { "0", "9", "2", "5"};

    private bool _isFinished = false;
    private int _passwordCount = 0;

    public int PasswordCount
    {
        get { return _passwordCount;  }
        set { _passwordCount = value; }
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
        //load scene
    }
}
