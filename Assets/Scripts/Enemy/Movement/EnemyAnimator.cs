using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [Header("Required components")]
    [SerializeField] private Animator _enemyAnimator;

    [Header("Options for Idle animation")]
    //[SerializeField] private AnimationClip[] _idleAnimations;

    #region Names (string) of parametres
    private string _nameIdleParameter = "Idle";
    private string _nameBlendTreeParameter = "BlendTree";
    private string _nameDetectedParameter = "Detected";
    private string _nameCanMoveParameter = "CanMove";
    private string _nameCanShootParameter = "CanShoot";
    #endregion

    private float[] _idleIndex = { 0, 1 };
    private int _currentIdleNum;


    private void Awake()
    {
        _enemyAnimator = GetComponent<Animator>();

        _enemyAnimator.ResetTrigger(_nameDetectedParameter);
        _enemyAnimator.ResetTrigger(_nameCanShootParameter);
        
        _enemyAnimator.SetFloat(_nameBlendTreeParameter, 0);

        Idle();
    }
    public void Idle()
    {
        _enemyAnimator.SetBool(_nameCanMoveParameter, false);

        _currentIdleNum = Random.Range(0, 2);
        _enemyAnimator.SetFloat(_nameIdleParameter, _idleIndex[_currentIdleNum]);
    }
    public void Move()
    {
        _enemyAnimator.SetBool(_nameCanMoveParameter, true);
    }
    public void Detect()
    {
        _enemyAnimator.SetTrigger(_nameDetectedParameter);
    }

    public void Shoot() //it is necessary to choose button
    {
        _enemyAnimator.SetTrigger(_nameCanShootParameter);
    }
}
