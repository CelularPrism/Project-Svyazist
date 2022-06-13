using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMovement : MonoBehaviour
{
    [SerializeField] private string _animationName;

    private Animator _sliderAnimation;
    private CircleCollider2D _sliderCollider;
    private RectTransform _rectTransform;

    public Vector3 SliderPosition
    {
        get { return _rectTransform.anchoredPosition3D; }
    }

    public float SliderSize
    {
        get { return _sliderCollider.radius * transform.localScale.x; }
    }
    public float SliderSpeed
    {
        get { return _sliderAnimation.speed; }
        set 
        {
            _sliderAnimation.speed = value;
        }
    }
    private void Awake()
    {
        _sliderAnimation = GetComponent<Animator>();
        _sliderCollider = GetComponent<CircleCollider2D>();
        _rectTransform = GetComponent<RectTransform>();
    }
    public void RestartPosition()
    {
        _sliderAnimation.Play(_animationName, -1, 0);
    }
}
