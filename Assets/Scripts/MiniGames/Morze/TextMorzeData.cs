using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMorzeData : MonoBehaviour
{
    [Header("Main Text")]
    [SerializeField] private Image[] _mainImages;

    [Header("Dots and Space")]
    [SerializeField] private Sprite _dotDefaultImage;
    [SerializeField] private Sprite _spaceDefaultImage;
    [SerializeField] private Sprite _dotCorrecttImage;
    [SerializeField] private Sprite _spaceCorrectImage;
    [SerializeField] private Sprite _dotWrongtImage;
    [SerializeField] private Sprite _spaceWrongImage;

    [Header("Size for dot")]
    [SerializeField] private float _scaleDotWidth = 25;
    [SerializeField] private float _scaleDotYHeight = 25;

    [Header("Size for space")]
    [SerializeField] private float _scaleSpaceWidth = 50;
    [SerializeField] private float _scaleSpaceHeight = 25;

    [Header("Image for Set")]
    [SerializeField] private Image _setImages;
    [SerializeField] private Animator _setImageAnimator;

    [Header("Selecter window")]
    [SerializeField] private Image _selecterWindow;

    [Header("MorzeController")]
    [SerializeField] private MorzeController _morzeController;

    private int[] _images; 
    private int _index;
    private int _indexImages;

    public Image SelecterWindow
    {
        get { return _selecterWindow; }
    }
    public Image SetImage
    {
        get { return _setImages; }
    }
    public int CurrentSymbol
    {
        get 
        { return _images[_index - 1]; }
    }
    public int FullAnswer
    {
        get { return _mainImages.Length; }
    }
    public int CurrentIndexSymbol
    {
        get { return _index - 1; }
    }
    private void OnEnable()
    {
        _setImages = GameObject.FindGameObjectWithTag("SetText").GetComponent<Image>();
        _setImageAnimator = _setImages.GetComponent<Animator>();
        _setImages.enabled = false;
        _setImageAnimator.enabled = false;

        Initialaze();
    }
    private void RememberImage(int picture)
    {
        _images[_indexImages] = picture;
        _indexImages++;
    }
    public void Initialaze()
    {
        _index = 0;
        _indexImages = 0;

        _images = new int[_mainImages.Length];
            foreach (Image image in _mainImages)
            {
                int picture = Random.Range(0, 2);
                if (picture == 0)
                {
                    image.sprite = _dotDefaultImage;
                    image.rectTransform.sizeDelta = new Vector2(_scaleDotWidth, _scaleDotYHeight);

                    RememberImage(picture);
                }
                else
                {
                    image.sprite = _spaceDefaultImage;
                    image.rectTransform.sizeDelta = new Vector2(_scaleSpaceWidth, _scaleSpaceHeight);
                    
                    RememberImage(picture);
                }
            } 
    }
    public void SetNewSymbol()
    {
        if (_images[_index] == 0)
        {
            _setImages.sprite = _dotCorrecttImage;
            _setImageAnimator.speed = 1.3f;
        }
        else
        {
            _setImages.sprite = _spaceCorrectImage;
            _setImageAnimator.speed = 1.0f;
        }
        _setImages.rectTransform.sizeDelta = _mainImages[_index].rectTransform.sizeDelta;

        _setImages.enabled = true;

        _setImageAnimator.enabled = true;
        _setImageAnimator.Play("Movement", -1, 0);

        _index++;

        _morzeController.AllowedPlay = true;
    }
    public void UpdateSprite(bool result)
    {
        if (result)
        {
            if (_images[_index - 1] == 0)
                _mainImages[_index - 1].sprite = _dotCorrecttImage;
            else
                _mainImages[_index - 1].sprite = _spaceCorrectImage;
        }
        else
        {
            if (_images[_index - 1] == 0)
                _mainImages[_index - 1].sprite = _dotWrongtImage;
            else
                _mainImages[_index - 1].sprite = _spaceWrongImage;
        }

    }
}
