using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(BoxCollider))]
public class Movement : MonoBehaviour
{
    private PlayerAction _inputActions;
    private CharacterController _character;
    private BoxCollider _collider;

    private Vector3 _moveInput;

    private bool _isMove;
    private bool _isRun;

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

        _inputActions.Player.SitDown.performed += sit => SpeedSitDown(true);
        _inputActions.Player.SitDown.canceled += sit => SpeedSitDown(false);

        _character = GetComponent<CharacterController>();
        _collider = GetComponent<BoxCollider>();
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

    public void SpeedSitDown(bool sitDown)
    {
        Debug.Log(sitDown);
        if (sitDown)
        {
            _collider.center = new Vector3(0f, _collider.center.y * 2, 0f);
            _collider.size /= 2;
            speed /= 2;
        }
        else
        {
            _collider.center = new Vector3(0f, _collider.center.y / 2, 0f);
            _collider.size *= 2;
            speed *= 2;
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
