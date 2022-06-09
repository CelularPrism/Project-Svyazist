using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMovement : MonoBehaviour
{
    private Animator _sliderAnimation;
    private SphereCollider _sliderCollider;

    public Vector3 SliderPosition
    {
        get { return this.transform.position; }
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
        _sliderCollider = GetComponent<SphereCollider>();
    }
    public void RestartPosition()
    {
        _sliderAnimation.Play("SliderMovement", -1, 0);
    }
}
