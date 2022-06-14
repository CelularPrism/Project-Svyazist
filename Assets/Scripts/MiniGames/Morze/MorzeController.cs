using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MorzeController : MonoBehaviour
{
    [SerializeField] private GameObject _headerImageEvil;
    [SerializeField] private GameObject _headerImageGood;

    private PlayerAction _inputActions;

    private TextMorzeData _textMorzeData;

    private float _rightSizeSelecter;
    private float _leftSizeSelecter;

    private float _rightSizeSetImage;
    private float _leftSizeSetImage;

    private int _countOfCorrectAnswer = 0;


    private void Awake()
    {
        _inputActions = new PlayerAction();
        _inputActions.Player.Enable();
        _inputActions.Player.Morze.canceled += perf => CheckSymbolPosition(perf);

        _textMorzeData = GetComponent<TextMorzeData>();

        _headerImageEvil.SetActive(true);
        _headerImageGood.SetActive(false);

    }
    private void Start()
    {
        _rightSizeSelecter = _textMorzeData.SelecterWindow.rectTransform.anchoredPosition.x 
            + ((_textMorzeData.SelecterWindow.GetComponent<BoxCollider2D>().size.x / 2) * _textMorzeData.SelecterWindow.transform.localScale.x);
        _leftSizeSelecter = _textMorzeData.SelecterWindow.rectTransform.anchoredPosition.x
            - ((_textMorzeData.SelecterWindow.GetComponent<BoxCollider2D>().size.x / 2) * _textMorzeData.SelecterWindow.transform.localScale.x);

        Debug.Log("leftSizeSelecter " + _leftSizeSelecter + ", rightSizeSelecter " + _rightSizeSelecter);
    }
    private void CheckSymbolPosition(InputAction.CallbackContext perf)
    {
        _rightSizeSetImage = _textMorzeData.SetImage.rectTransform.anchoredPosition.x + (_textMorzeData.SetImage.rectTransform.sizeDelta.x / 2);
        _leftSizeSetImage = _textMorzeData.SetImage.rectTransform.anchoredPosition.x - (_textMorzeData.SetImage.rectTransform.sizeDelta.x / 2);

        if (_rightSizeSetImage > _rightSizeSelecter && _leftSizeSetImage < _leftSizeSelecter)
        {
            if (perf.duration < 0.3f && _textMorzeData.CurrentSymbol == 0)
            {
                WinMatch();
            }
            else if (perf.duration > 0.3f && _textMorzeData.CurrentSymbol == 1)
            {
                WinMatch();
            }
            else
                LoseMatch();
        }
        else
            LoseMatch();

        Debug.Log("leftSize " + _leftSizeSetImage + ", rightSize" + _rightSizeSetImage);

        Debug.Log("Duration" + perf.duration * 100);
    }
    public void WinMatch()
    {
        _countOfCorrectAnswer++;
        _textMorzeData.UpdateSprite(true);
        if (_textMorzeData.CurrentIndexSymbol < _textMorzeData.FullAnswer - 1)
            _textMorzeData.SetNewSymbol();
        else
            WinGame();
    }
    public void LoseMatch()
    {
        if (_textMorzeData.CurrentIndexSymbol < _textMorzeData.FullAnswer - 1)
        {
            _textMorzeData.UpdateSprite(false);
            _textMorzeData.SetNewSymbol();
        }
        else
            LostGame();
    }
    public void WinGame()
    {
        if (_countOfCorrectAnswer / _textMorzeData.FullAnswer > 0.5f)
        {
            Debug.Log("You Win, score is" + _countOfCorrectAnswer / _textMorzeData.FullAnswer);
            _headerImageEvil.SetActive(false);
            _headerImageGood.SetActive(false);
            //reload privious scene after 2 seconds
        }
        else
        {
            Debug.Log("You Lose, score is" + _countOfCorrectAnswer / _textMorzeData.FullAnswer);
            LostGame();
        }
    }
    public void LostGame()
    {
        _countOfCorrectAnswer = 0;
        _textMorzeData.Initialaze();
    }
}
