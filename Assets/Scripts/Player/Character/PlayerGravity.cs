using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class PlayerGravity : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private LayerMask groundMask;
 
    [SerializeField] private float gravity;
    [SerializeField] private float radius;

    private bool _isGround;
    private float _speed;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        radius = GetComponent<SphereCollider>().radius;
        _speed = 0f;
    }

    void FixedUpdate()
    {
        _isGround = Physics.CheckSphere(transform.position, radius, groundMask);

        if (_isGround)
        {
            _speed = 0;
        } else
        {
            _speed += gravity * Time.fixedDeltaTime;
        }

        Vector3 movement = new Vector3(0f, _speed, 0f);
        characterController.Move(movement);
    }
}
