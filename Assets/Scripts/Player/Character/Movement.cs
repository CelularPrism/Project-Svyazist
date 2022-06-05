using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    private PlayerAction _inputActions;
    private Rigidbody _rigidBody;

    private Vector3 _moveInput;

    [SerializeField] private float speed;

    void Awake()
    {
        _inputActions = new PlayerAction();
        _inputActions.Enable();

        _inputActions.Player.Movement.performed += move =>
        {
            _moveInput = new Vector3(move.ReadValue<Vector2>().x, 0f, move.ReadValue<Vector2>().y);
        };

        _rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        _rigidBody.velocity = _moveInput * speed;
    }
}
