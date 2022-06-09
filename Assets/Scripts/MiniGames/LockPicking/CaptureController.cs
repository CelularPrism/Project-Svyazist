using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CaptureController : MonoBehaviour
{
    [SerializeField] private SliderMovement _sliderMovement;
    [SerializeField] private CaptureData _captureData;
    [SerializeField] private GameObject _mistakeImage;

    private PlayerAction _inputActions;

    private void Awake()
    {
        _inputActions = new PlayerAction();
        _inputActions.Player.Enable();
        _inputActions.Player.LockPicking.performed += perf => CheckSliderPosition();
    }

    private void Start()
    {
        _captureData.CurrentIndexSliderSpeed = 0;
        _captureData.CurrentIndexDetectionZone = 0;
        _mistakeImage.SetActive(false);

        Inizialize();
    }
    private void Inizialize()
    {
        _sliderMovement.RestartPosition();

        _sliderMovement.SliderSpeed = _captureData.SliderSpeed;
        _captureData.SetNextDetectionZones();
    }
    private void CheckSliderPosition()
    {
        Debug.Log("Button on" + Time.realtimeSinceStartup);
        StopAllCoroutines();

        if (_sliderMovement.SliderPosition.x < (_captureData.RightSize - _sliderMovement.SliderSize) 
            && _sliderMovement.SliderPosition.x > (_captureData.LeftSize + _sliderMovement.SliderSize))
        {
            if (_captureData.CurrentIndexSliderSpeed < 4)
                _captureData.CurrentIndexSliderSpeed++;
            if (_captureData.CurrentIndexDetectionZone < 4)
                _captureData.CurrentIndexDetectionZone++;

            Inizialize();
        }
        else
            StartCoroutine("SetMistakeWindow");
    }
    private IEnumerator SetMistakeWindow()
    {
        _mistakeImage.SetActive(true);

        yield return new WaitForSeconds(0.2f);

        _mistakeImage.SetActive(false);
    }
}
