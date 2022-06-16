using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStealthController : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    private bool _isDetected = false;

    /*public bool IsDetected()
    {
        return _isDetected;
    }*/

    public void Detected()
    {
        _isDetected = true;
        gameController.Dead();
    }
}
