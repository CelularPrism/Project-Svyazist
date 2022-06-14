using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    private PlayerAction _inputActions;
    private CharacterController _character;

    private Vector3 _moveInput;

    [SerializeField] private bool _isMove;
    [SerializeField] private bool _isRun;

    [SerializeField] private PlayerGravity gravity;
    [SerializeField] private PlayerRotater rotater;
    [SerializeField] private float speed;

    [SerializeField] private PlayerAnimatorMovement _playerAnimatorMovement; //Script Movement is defined which animation should play

    private void Awake()
    {
        _inputActions = new PlayerAction();
        _inputActions.Enable();

        _inputActions.Player.Movement.performed += move =>
        {
            SetMoveInput(move);
        };

        _inputActions.Player.Run.performed += run => _isRun = true;  //adding button for running
        _inputActions.Player.Run.canceled += run => _isRun = false;  //adding button for running

        _character = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        if (DialogueManager.GetInstance()._dialogueIsPlaying)
        {
            return;
        }

        _moveInput = new Vector3(_moveInput.x, gravity.GetGravitySpeed(), _moveInput.z);
        
        if (!_isRun)
            _character.Move(_moveInput * speed * Time.fixedDeltaTime);
        else
            _character.Move(_moveInput * (1.7f * speed) * Time.fixedDeltaTime);
    }

    private void SetMoveInput(InputAction.CallbackContext move)
    {
        _moveInput = new Vector3(move.ReadValue<Vector2>().x, 0f, move.ReadValue<Vector2>().y);
        rotater.Rotate(_moveInput);

        if (_moveInput != Vector3.zero)
        {
            _isMove = true;
            if (!_isRun)
                _playerAnimatorMovement.Move();
            else
                _playerAnimatorMovement.Run();
        }
        else
        {
            _isMove = false;
            _playerAnimatorMovement.Idle();
        }
    }
    public Vector3 GetMoveInput() //can be delete
    {
        return _moveInput;
    }

    public bool IsMove() //can be delete
    {
        return _isMove;
    }
}
