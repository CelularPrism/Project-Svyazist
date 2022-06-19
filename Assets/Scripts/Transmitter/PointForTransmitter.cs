using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointForTransmitter : MonoBehaviour
{
    [SerializeField] private int mask;
    [SerializeField] private TransmitterDistance transmitter;
    [SerializeField] private GameObject ButtonsCue;

    private bool _isActive;
    private PlayerAction _inputActions;

    private int _buildIndex = 3;

    void Start()
    {
        _inputActions = new PlayerAction();
        _inputActions.Player.GetItem.performed += perf => UseTransmitter();

        _isActive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("In");
        if (other.gameObject.layer == mask)
        {
            ButtonsCue.SetActive(true);
            Debug.Log("In2");
            _inputActions.Enable();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Out");
        if (other.gameObject.layer == mask)
        {
            ButtonsCue.SetActive(false);
            Debug.Log("Out2");
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
            SceneManager.LoadScene(_buildIndex);
        }
    }
}
