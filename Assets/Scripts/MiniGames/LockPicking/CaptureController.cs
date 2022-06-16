using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CaptureController : MonoBehaviour
{
    [SerializeField] private Image[] _ledControlImages;
    [SerializeField] private Sprite _defaultLedImage;
    [SerializeField] private Sprite _mistakeLedImage;
    [SerializeField] private Sprite _correctLedImage;

    [SerializeField] private SliderMovement _sliderMovement;
    [SerializeField] private CaptureData _captureData;

    private MiniGamesAction _inputActions;

    private void Awake()
    {
        _inputActions = new MiniGamesAction();
        _inputActions.MiniGames.Enable();
        _inputActions.MiniGames.LockPicking.performed += perf => CheckSliderPosition();
    }

    private void Start()
    {
        _captureData.CurrentIndex = 0;
        _sliderMovement.SliderSpeed = _captureData.SliderSpeed;

        Inizialize();
    }
    private void Inizialize()
    {
        _sliderMovement.RestartPosition();

        _captureData.SetNextDetectionZones();
    }
    private void CheckSliderPosition()
    {
        Debug.Log("Button on" + Time.realtimeSinceStartup);
        Debug.Log("Position" + _sliderMovement.SliderPosition.x);
        Debug.Log("Right size " + _captureData.RightSize + "Left size " + _captureData.LeftSize);
        StopAllCoroutines();

        if (_sliderMovement.SliderPosition.x < (_captureData.RightSize - _sliderMovement.SliderSize) 
            && _sliderMovement.SliderPosition.x > (_captureData.LeftSize + _sliderMovement.SliderSize))
        {
            if (_captureData.CurrentIndex < 4)
            {
                Debug.Log("Before" + _captureData.CurrentIndex);
                _captureData.CurrentIndex++;
                Debug.Log("After" + _captureData.CurrentIndex);
            }
            StartCoroutine("SetCorrectWindow");
            Inizialize();
        }
        else
            StartCoroutine("SetMistakeWindow");
    }
    private IEnumerator SetCorrectWindow()
    {
        _ledControlImages[_captureData.CurrentIndex - 1].sprite = _correctLedImage;

        yield return null;
    }
    private IEnumerator SetMistakeWindow()
    {
        _ledControlImages[_captureData.CurrentIndex].sprite = _mistakeLedImage;

        yield return new WaitForSeconds(0.2f);

        _ledControlImages[_captureData.CurrentIndex].sprite = _defaultLedImage;
    }
}
