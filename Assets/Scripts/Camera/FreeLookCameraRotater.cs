using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineFreeLook))]
public class FreeLookCameraRotater : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float inaccuracy;
    [SerializeField] private float[] XAxisValues;
    [SerializeField] private Transform player;

    private CinemachineFreeLook _freeLook;
    private PlayerAction _inputActions;

    private float _xAxisValue;
    private int _index;

    void Start()
    {
        _freeLook = GetComponent<CinemachineFreeLook>();
        _inputActions = new PlayerAction();
        _inputActions.Enable();

        _inputActions.Player.RotateCameraLeft.performed += perf => RotateLeft();
        _inputActions.Player.RotateCameraRight.performed += perf => RotateRight();
    }

    private void FixedUpdate()
    {
        if (_freeLook.m_XAxis.Value >= _freeLook.m_XAxis.m_MaxValue - inaccuracy)
        {
            _freeLook.m_XAxis.Value = 0;
            _xAxisValue = 0;
        }

        if (_freeLook.m_XAxis.Value != _xAxisValue)
        {
            _freeLook.m_XAxis.Value = Mathf.Lerp(_freeLook.m_XAxis.Value, _xAxisValue, speed * Time.deltaTime);//_speed;
        }
    }

    private void RotateLeft()
    {
        if (_freeLook.m_XAxis.Value >= Mathf.Abs(_xAxisValue - inaccuracy) 
            || _freeLook.m_XAxis.Value <= inaccuracy)
        {
            _index++;
            float value = 0;

            if (_index == XAxisValues.Length)
            {
                value = _freeLook.m_XAxis.m_MaxValue;
                _index = 0;
            }

            _xAxisValue = XAxisValues[_index] + value;
        }
    }

    private void RotateRight()
    {
        if (_freeLook.m_XAxis.Value >= Mathf.Abs(_xAxisValue - inaccuracy) 
            || _freeLook.m_XAxis.Value <= inaccuracy)
        {
            _index--;
            if (_index < 0)
            {
                _freeLook.m_XAxis.Value = _freeLook.m_XAxis.m_MaxValue - 2;
                _index = XAxisValues.Length - 1;
            }

            _xAxisValue = XAxisValues[_index];
        }
    }
}
