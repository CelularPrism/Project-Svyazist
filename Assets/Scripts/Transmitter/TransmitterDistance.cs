using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmitterDistance : MonoBehaviour
{
    [SerializeField] private int mask;

    private bool _isActive;
    private Transform _playerTrans;
    private float _distance;

    void Start()
    {
        _isActive = false;
    }

    void Update()
    {
        if (_isActive)
        {
            Vector3 pos = transform.position;
            Vector3 plrPos = _playerTrans.position;
            _distance = Vector3.Distance(plrPos, pos);
            //Debug.LogWarning(_distance);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == mask)
        {
            Debug.Log("Enter");
            _playerTrans = other.transform;
            _isActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == mask)
        {
            Debug.Log("Exit");
            _isActive = false;
        }
    }

    public void DisableTransmitter()
    {
        _isActive = false;
    }

    public bool GetState()
    {
        return _isActive;
    }

    public float GetDistance()
    {
        return _distance;
    }
}
