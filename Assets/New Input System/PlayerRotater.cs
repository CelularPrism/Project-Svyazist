using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[RequireComponent(typeof(Movement))]
public class PlayerRotater : MonoBehaviour
{
    [SerializeField] private Movement plrMovement;
    [SerializeField] private float speedRotated;

    private bool _isMoveDown;

    void Start()
    {
        plrMovement = GetComponentInParent<Movement>();
    }

    public void Rotate(Vector3 movement)
    {
        float y = 0f;

        if (movement.z > 0)
        {
            y = 0f;
            _isMoveDown = false;
        }
        else if (movement.z < 0)
        {
            y = 180f;
            _isMoveDown = true;
        }

        if (movement.x > 0)
        {
            y = 90f;
        }
        else if (movement.x < 0)
        {
            y = 270f;
        }

        transform.rotation = Quaternion.Euler(0f, y, 0f);
    }
}