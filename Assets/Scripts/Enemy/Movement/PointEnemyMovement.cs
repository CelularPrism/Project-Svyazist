using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float stayTime;

    public float GetSpeed()
    {
        return speed;
    }

    public float GetStayTime()
    {
        return stayTime;
    }
}
