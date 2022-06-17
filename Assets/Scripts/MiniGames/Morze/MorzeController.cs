using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class MorzeController : MonoBehaviour
{
    [SerializeField] private GameObject _headerImageEvil;
    [SerializeField] private GameObject _headerImageGood;

    private MiniGamesAction _inputActions;

    private TextMorzeData _textMorzeData;

    private float _rightSizeSelecter;
    private float _leftSizeSelecter;

    private float _rightSizeSetImage;
    private float _leftSizeSetImage;

    private int _countOfCorrectAnswer = 0;

    public string EventWrong;
    public string EventRight;


    private void Awake()
    {
        _inputActions = new MiniGamesAction();
        _inputActions.MiniGames.Enable();
        _inputActions.MiniGames.Morze.performed += perf => 
        //_inputActions.Player.Morze.canceled += perf =>
        {
            if (perf.interaction is TapInteraction)
            //if (perf.duration < 0.2f)
            {
                Debug.Log(perf.interaction + "  short " + perf.duration);
                CheckDotPosition(perf);
            }
            else if (perf.interaction is HoldInteraction)
            //else if (0.2f > perf.duration && perf.duration < 0.8f)
            {
                Debug.Log(perf.interaction + "  long " + perf.duration);
                CheckSpacePosition(perf);
            }
        };
        _textMorzeData = GetComponent<TextMorzeData>();

        //_headerImageEvil.SetActive(true);
        //_headerImageGood.SetActive(false);

    }
    private void Start()
    {
        _rightSizeSelecter = _textMorzeData.SelecterWindow.rectTransform.anchoredPosition.x
            + ((_textMorzeData.SelecterWindow.GetComponent<BoxCollider2D>().size.x / 2) * _textMorzeData.SelecterWindow.transform.localScale.x);
        _leftSizeSelecter = _textMorzeData.SelecterWindow.rectTransform.anchoredPosition.x
            - ((_textMorzeData.SelecterWindow.GetComponent<BoxCollider2D>().size.x / 2) * _textMorzeData.SelecterWindow.transform.localScale.x);

        Debug.Log("leftSizeSelecter " + _leftSizeSelecter + ", rightSizeSelecter " + _rightSizeSelecter);

        _textMorzeData.SetNewSymbol();
    }
    private void CheckDotPosition(InputAction.CallbackContext perf)
    {
        _rightSizeSetImage = _textMorzeData.SetImage.rectTransform.anchoredPosition.x + (_textMorzeData.SetImage.rectTransform.sizeDelta.x / 2);
        _leftSizeSetImage = _textMorzeData.SetImage.rectTransform.anchoredPosition.x - (_textMorzeData.SetImage.rectTransform.sizeDelta.x / 2);

        int imageNum = _textMorzeData.CurrentSymbol;

        if (_rightSizeSetImage < _rightSizeSelecter && _leftSizeSetImage > _leftSizeSelecter)
        {
            if (imageNum == 0)
            {
                _countOfCorrectAnswer++;
                WinMatch();
            }
            else
                LoseMatch();
        }
        else
            LoseMatch();
    }    
    private void CheckSpacePosition(InputAction.CallbackContext perf)
    {
        _rightSizeSetImage = _textMorzeData.SetImage.rectTransform.anchoredPosition.x + (_textMorzeData.SetImage.rectTransform.sizeDelta.x / 2);
        _leftSizeSetImage = _textMorzeData.SetImage.rectTransform.anchoredPosition.x - (_textMorzeData.SetImage.rectTransform.sizeDelta.x / 2);

        int imageNum = _textMorzeData.CurrentSymbol;

        if (_rightSizeSetImage < _rightSizeSelecter && _leftSizeSetImage > _leftSizeSelecter)
        {
            if (imageNum == 1)
            {
                _countOfCorrectAnswer++;
                WinMatch();
            }
            else
                LoseMatch();
                
        }
        else
            LoseMatch();
    }
    public void WinMatch()
    {
        _textMorzeData.UpdateSprite(true);
        RightSound();

        if (_textMorzeData.CurrentIndexSymbol < _textMorzeData.FullAnswer - 1)
            _textMorzeData.SetNewSymbol();
        else
        {
            _textMorzeData.SetImage.GetComponent<Animator>().enabled = false;
            ScoreGame();
        }
    }
    public void LoseMatch()
    {
        WrongSound();
        _textMorzeData.UpdateSprite(false);
        if (_textMorzeData.CurrentIndexSymbol < _textMorzeData.FullAnswer - 1)
        {
            _textMorzeData.SetNewSymbol();
        }
        else
            ScoreGame();
    }
    public void ScoreGame()
    {
        Debug.Log("_countOfCorrectAnswer " + _countOfCorrectAnswer + "_textMorzeData.FullAnswer" + _textMorzeData.FullAnswer);
        if (_countOfCorrectAnswer > (0.5f * _textMorzeData.FullAnswer))
        {
            
            //_headerImageEvil.SetActive(false);
            //_headerImageGood.SetActive(true);
            //reload privious scene after 2 seconds
        }
        else
        {
            LostGame();
            WrongSound();
        }
    }
    public void LostGame()
    {
        _countOfCorrectAnswer = 0;
        _textMorzeData.Initialaze();
        _textMorzeData.SetNewSymbol();
    }
    
    public void WrongSound()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(EventWrong, gameObject);
    }
    public void RightSound()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(EventRight, gameObject);
    }
}
