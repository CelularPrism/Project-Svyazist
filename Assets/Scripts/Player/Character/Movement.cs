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

    private bool _isMove;

    [SerializeField] private PlayerGravity gravity;
    [SerializeField] private PlayerRotater rotater;
    [SerializeField] private float speed;

    void Awake()
    {
        _inputActions = new PlayerAction();
        _inputActions.Enable();

        _inputActions.Player.Movement.performed += move =>
        {
            SetMoveInput(move);
        };

        _character = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        if (DialogueManager.GetInstance()._dialogueIsPlaying)
        {
            return;
        }

        _moveInput = new Vector3(_moveInput.x, gravity.GetGravitySpeed(), _moveInput.z);
        _character.Move(_moveInput * speed * Time.fixedDeltaTime);
    }

    private void SetMoveInput(InputAction.CallbackContext move)
    {
        _moveInput = new Vector3(move.ReadValue<Vector2>().x, 0f, move.ReadValue<Vector2>().y);
        rotater.Rotate(_moveInput);

        if (_moveInput != Vector3.zero)
        {
            _isMove = true;
        } else
        {
            _isMove = false;
        }
    }

    public Vector3 GetMoveInput()
    {
        return _moveInput;
    }

    public bool IsMove()
    {
        return _isMove;
    }
}
