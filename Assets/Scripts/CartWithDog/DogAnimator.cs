using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAnimator : MonoBehaviour
{
    [SerializeField] private Animator _dogAnimator;

    private string _nameSpeedFactor = "SpeedFactor";
    private string _nameWarning = "Warning";

    private void Awake()
    {
        _dogAnimator = GetComponentInChildren<Animator>();

        _dogAnimator.ResetTrigger(_nameWarning);
    }
    public void Move()
    {
        _dogAnimator.SetFloat(_nameSpeedFactor, 0.5f);
    }
    public void SitDown()
    {
        _dogAnimator.SetFloat(_nameSpeedFactor, 0f);
    }
    public void Search()
    {
        _dogAnimator.SetFloat(_nameSpeedFactor, 1f);
    }
    public void Find()
    {
        _dogAnimator.SetTrigger(_nameWarning);
    }
}
