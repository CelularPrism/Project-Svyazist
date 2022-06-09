using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineFreeLook))]
public class FreeLookCameraRotater : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float[] XAxisValues;

    private CinemachineFreeLook _freeLook;
    private PlayerAction _inputActions;

    private float[] _speedArray = new float[2]; 
    private float _xAxisValue;
    private int _index;

    void Start()
    {
        _speedArray[0] = speed;
        _speedArray[1] = -speed;

        _freeLook = GetComponent<CinemachineFreeLook>();
        _inputActions = new PlayerAction();
        _inputActions.Enable();

        _inputActions.Player.RotateCameraLeft.performed += perf => RotateLeft();
        _inputActions.Player.RotateCameraRight.performed += perf => RotateRight();
    }

    private void FixedUpdate()
    {
        if (_freeLook.m_XAxis.Value >= 360f)
            _freeLook.m_XAxis.Value = 0;

        if (_freeLook.m_XAxis.Value != _xAxisValue)
            _freeLook.m_XAxis.Value += speed;
    }

    private void RotateLeft()
    {
        _index++;
        if (_index == XAxisValues.Length)
            _index = 0;

        _xAxisValue = XAxisValues[_index];
        speed = _speedArray[0];
    }

    private void RotateRight()
    {
        _index--;
        if (_index < 0)
            _index = XAxisValues.Length - 1;

        _xAxisValue = XAxisValues[_index];
        speed = _speedArray[1];
    }
}
