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

    private string _nameMovementParameter = "Movement";
    private string _nameIdleParameter = "IdleIndex";
    private string _nameGetItemParameter = "GetItem";
    private string _nameUseItemParameter = "UseItem";

    private float[] _idleIndex = { 0, 0.5f, 1};
    private float _movement;
    private int _currentIdleNum;
    

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();

        /*_inputActions = new PlayerAction();
        _inputActions.Enable();
        _inputActions.Player.GetItem.performed += perf => GetItem();*/

        Idle();

        animator.ResetTrigger(_nameGetItemParameter);
        animator.ResetTrigger(_nameUseItemParameter);
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
    private IEnumerator ChangeIdleAnimation()
    {
        while (_movement == 0f)
        {
            _currentIdleNum = Random.Range(0, _idleAnimations.Length);

            yield return new WaitForSeconds(5f);
        }
    }
}
