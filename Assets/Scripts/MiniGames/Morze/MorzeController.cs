using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.SceneManagement;

public class MorzeController : MonoBehaviour
{
    [SerializeField] private Animator _tipAnimator;
    [SerializeField] private TextMorzeData _textMorzeData;
    [SerializeField] private bool _allowedPlay;
    [SerializeField] private int _buildIndex;

    private MiniGamesAction _inputActions;

    private float _rightSizeSelecter;
    private float _leftSizeSelecter;

    private float _rightSizeSetImage;
    private float _leftSizeSetImage;

    private int _countOfCorrectAnswer = 0;

    public string EventWrong;
    public string EventRight;

    public bool AllowedPlay
    {
        get { return _allowedPlay; }
        set { _allowedPlay = value; }
    }
    private void OnEnable()
    {
        _inputActions = new MiniGamesAction();
        _inputActions.MiniGames.Enable();

        _inputActions.MiniGames.MorzeButton.started += perf => 
        {
            if (_allowedPlay)
            {
                CheckFirstPosition(perf);
            }
        };
        _inputActions.MiniGames.MorzeButton.canceled += perf =>
        {
            if (_allowedPlay)
            {
                if (perf.duration <= 0.15f)
                {
                    Debug.Log("CheckDotPosition with duration " + perf.duration);
                    CheckDotPosition(perf);
                }
                else if (perf.duration > 0.15f && perf.duration < 0.55f)
                {
                    Debug.Log("CheckSpacePosition with duration " + perf.duration);
                    CheckSpacePosition(perf);
                }
                else
                {
                    //Debug.Log("Long Hold" + Time.realtimeSinceStartup);
                    ResultMatch(false);
                }
            }
        };        
    }
    private void Start()
    {
        _rightSizeSelecter = _textMorzeData.SelecterWindow.rectTransform.anchoredPosition.x
            + ((_textMorzeData.SelecterWindow.GetComponent<BoxCollider2D>().size.x / 2) * _textMorzeData.SelecterWindow.transform.localScale.x);
        _leftSizeSelecter = _textMorzeData.SelecterWindow.rectTransform.anchoredPosition.x
            - ((_textMorzeData.SelecterWindow.GetComponent<BoxCollider2D>().size.x / 2) * _textMorzeData.SelecterWindow.transform.localScale.x);

        _allowedPlay = false;
        _tipAnimator.SetBool("Tip", true); 
    }
    private void CheckDotPosition(InputAction.CallbackContext perf)
    {
        int dot = 0;
        CalculatePosition(dot);
    }    
    private void CheckSpacePosition(InputAction.CallbackContext perf)
    {
        int space = 1;
        CalculatePosition(space);
    }
    private void CheckFirstPosition(InputAction.CallbackContext perf)
    {
        _rightSizeSetImage = _textMorzeData.SetImage.rectTransform.anchoredPosition.x + (_textMorzeData.SetImage.rectTransform.sizeDelta.x / 2);
        _leftSizeSetImage = _textMorzeData.SetImage.rectTransform.anchoredPosition.x - (_textMorzeData.SetImage.rectTransform.sizeDelta.x / 2);

        //Debug.Log("Started" + _rightSizeSetImage + ", " + _leftSizeSetImage);

        if (_leftSizeSetImage < _leftSizeSelecter
            || _rightSizeSetImage > _rightSizeSelecter)
        {
            ResultMatch(false);
            WrongSound();
            Debug.Log("Wrong " + Time.realtimeSinceStartup);
        }
    }
    private void CalculatePosition(int symbol)
    {
        _rightSizeSetImage = _textMorzeData.SetImage.rectTransform.anchoredPosition.x + (_textMorzeData.SetImage.rectTransform.sizeDelta.x / 2);
        _leftSizeSetImage = _textMorzeData.SetImage.rectTransform.anchoredPosition.x - (_textMorzeData.SetImage.rectTransform.sizeDelta.x / 2);

        int imageNum = _textMorzeData.CurrentSymbol;

        if (_rightSizeSetImage < _rightSizeSelecter && _leftSizeSetImage > _leftSizeSelecter)
        {
            if (imageNum == symbol)
            {
                _countOfCorrectAnswer++;
                ResultMatch(true);
                RightSound();
                Debug.Log("Win" + Time.realtimeSinceStartup);
            }
            else
            {
                ResultMatch(false);
                WrongSound();
                Debug.Log("Wrong symbol" + Time.realtimeSinceStartup);
            }   
        }
        else
        {
            ResultMatch(false);
            WrongSound();
            Debug.Log("Lose" + _rightSizeSetImage + ", " + _leftSizeSetImage);
        }
    }
    public void ResultMatch(bool result)
    {
        _allowedPlay = false;
        _textMorzeData.UpdateSprite(result);

        if (_textMorzeData.CurrentIndexSymbol < _textMorzeData.FullAnswer - 1)
            Invoke("Restart", 0.7f);
        else
        {
            _textMorzeData.SetImage.GetComponent<Animator>().enabled = false;
            ScoreGame();
        }
    }
    public void Restart()
    {
        _textMorzeData.SetNewSymbol();
    }
    public void ScoreGame()
    {
        _inputActions.MiniGames.Disable();
        if (_countOfCorrectAnswer > (0.5f * _textMorzeData.FullAnswer))
        {
            Invoke("LoadNextLevel", 1f);
        }
        else
        {
            LostGame();
            WrongSound();
        }
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(_buildIndex);
    }
    public void LostGame()
    {
        /*_countOfCorrectAnswer = 0;
        _textMorzeData.Initialaze();
        _textMorzeData.SetNewSymbol();
        _inputActions.MiniGames.Enable();*/
        _countOfCorrectAnswer = 0;
        _textMorzeData.Initialaze();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
