using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Movement))]
public class PlayerAnimatorMovement : MonoBehaviour
{
    [Header("Required components")]
    [SerializeField] private Animator animator;

    [Header("Options for Idle animation")]
    [SerializeField] private AnimationClip[] _idleAnimations;

    private PlayerAction _inputActions;

    #region Names (string) of parametres
    private string _nameMovementParameter = "Movement";
    private string _nameIdleParameter = "IdleIndex";
    private string _nameGetItemParameter = "GetItem";
    private string _nameUseItemParameter = "UseItem";
    private string _nameSteathParameter = "Steath";
    private string _nameDeathParameter = "Death";
    private string _nameDeadParameter = "Dead";
    private string _nameEnterRadioSetParameter = "EnterRadioSet";
    #endregion

    private bool _steath = false;

    private float[] _idleIndex = { 0, 0.5f, 1};
    private float _movement;
    private int _currentIdleNum;
    

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();

        /*_inputActions = new PlayerAction();
        _inputActions.Enable();
        _inputActions.Player.GetItem.performed += perf => GetItem();*/

        animator.ResetTrigger(_nameGetItemParameter);
        animator.ResetTrigger(_nameUseItemParameter);
        animator.ResetTrigger(_nameDeadParameter);
        animator.ResetTrigger(_nameEnterRadioSetParameter);

        Idle();
    }
    void FixedUpdate()
    {
        if (_movement == 0f)
        {
            animator.SetFloat(_nameIdleParameter, _idleIndex[_currentIdleNum], 0.1f, Time.fixedDeltaTime);
        }
    }
    public void Idle()
    {
        _movement = 0f;
        animator.SetFloat(_nameMovementParameter, _movement);

        StartCoroutine("ChangeIdleAnimation");
    }
    public void Move()
    {
        StopAllCoroutines();
        
        _movement = 0.5f;
        animator.SetFloat(_nameMovementParameter, _movement);
    }
    public void Run()
    {
        StopAllCoroutines();

        _movement = 1f;
        animator.SetFloat(_nameMovementParameter, _movement);
    }
    public void GetItem()
    {
        StopAllCoroutines();
        animator.SetTrigger(_nameGetItemParameter);
    }
    public void UseItem()
    {
        StopAllCoroutines();
        animator.SetTrigger(_nameUseItemParameter);
    }    
    public void UseRadioSet()
    {
        StopAllCoroutines();
        animator.SetTrigger(_nameEnterRadioSetParameter);
    }
    public void GoToSteath() //it is necessary to choose button
    {
        StopAllCoroutines();
        animator.SetBool(_nameSteathParameter, true);
    }
    public void SetDeathFromEnemy()
    {
        StopAllCoroutines();
        animator.SetTrigger(_nameDeadParameter);
        animator.SetFloat(_nameDeathParameter, 0);
    }
    public void SetDeathFromMine()
    {
        StopAllCoroutines();
        animator.SetTrigger(_nameDeadParameter);
        animator.SetFloat(_nameDeathParameter, 1);
    }
    public void GoToStand() //it is necessary to choose button
    {
        StopAllCoroutines();
        animator.SetBool(_nameSteathParameter, false);

        StartCoroutine("ChangeIdleAnimation"); //changes
    }
    private IEnumerator ChangeIdleAnimation()
    {
        while (_movement == 0f)
        {
            _currentIdleNum = Random.Range(0, _idleAnimations.Length);

            yield return new WaitForSeconds(5f);
        }
    }
}
