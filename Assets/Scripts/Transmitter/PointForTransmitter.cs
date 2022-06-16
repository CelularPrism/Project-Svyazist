using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointForTransmitter : MonoBehaviour
{
    [SerializeField] private int mask;
    [SerializeField] private TransmitterDistance transmitter;

    private bool _isActive;
    private PlayerAction _inputActions;

    void Start()
    {
        _inputActions = new PlayerAction();
        _inputActions.Player.GetItem.performed += perf => UseTransmitter();

        _isActive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == mask)
        {
            _inputActions.Enable();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == mask)
        {
            _inputActions.Disable();
        }
    }

    private void UseTransmitter()
    {
        if (_isActive)
        {
            transmitter.DisableTransmitter();
            _isActive = false;
            Debug.Log("Use Transmitter");
        }
    }
}
