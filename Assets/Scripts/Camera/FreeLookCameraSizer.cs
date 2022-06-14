using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineFreeLook))]
public class FreeLookCameraSizer : MonoBehaviour
{
    [SerializeField] private float speed;

    [Header("Points up-down")]
    [Tooltip("Массив чисел идет по убыванию")]
    [SerializeField] private float[] YAxisValues;

    [Header("Start index")]
    [Tooltip("Индекс на котором будет находиться камера")]
    [SerializeField] private int index;

    private CinemachineFreeLook _freeLook;
    private PlayerAction _inputActions;

    private float _nowValue;

    void Start()
    {
        _freeLook = GetComponent<CinemachineFreeLook>();
        _inputActions = new PlayerAction();
        _inputActions.Enable();

        _inputActions.Player.SizeCameraDown.performed += perf => SizeCameraDown();
        _inputActions.Player.SizeCameraUp.performed += perf => SizeCameraUp();
        _nowValue = YAxisValues[index];
    }

    private void FixedUpdate()
    {
        _freeLook.m_YAxis.Value = Mathf.Lerp(_freeLook.m_YAxis.Value, _nowValue, speed * Time.fixedDeltaTime);
    }

    private void SizeCameraDown()
    {
        index++;
        if (index >= YAxisValues.Length)
        {
            index = YAxisValues.Length - 1;
        }

        _nowValue = YAxisValues[index];
    }

    private void SizeCameraUp()
    {
        index--;
        if (index < 0)
        {
            index = 0;
        }

        _nowValue = YAxisValues[index];
    }
}
