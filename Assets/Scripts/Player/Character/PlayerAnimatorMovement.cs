using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Movement))]
public class PlayerAnimatorMovement : MonoBehaviour
{
    [SerializeField] private Movement plrMovement;
    [SerializeField] private Animator animator;

    void Start()
    {
        plrMovement = GetComponent<Movement>();
    }

    void FixedUpdate()
    {
        if (!plrMovement.IsMove())
        {
            float rnd = Random.Range(0f, 1f);
            animator.SetFloat("BlendStand", rnd);
        }
    }
}
