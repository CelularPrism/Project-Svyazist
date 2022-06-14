using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float stayTime;
    [SerializeField] private Transform lookAtPoint;

    public bool isLook;

    private void Awake()
    {
        if (lookAtPoint != null)
            isLook = true;
        else
            isLook = false;
    }

    public Vector3 GetLookAtPoint()
    {
        return lookAtPoint.position;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public float GetStayTime()
    {
        return stayTime;
    }
}
