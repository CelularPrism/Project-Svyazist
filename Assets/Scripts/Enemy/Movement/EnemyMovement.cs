using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Points")]
    [SerializeField] private PointEnemyMovement[] _arrayPoints;

    [Header("Speed enemy")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private bool staticSpeed;

    [Header("State enemy")]
    public bool isMove;

    private PointEnemyMovement _nowPoint;
    private float _stayTime;

    private int _indexPoint;
    private int _pointChanger;

    void Start()
    {
        _pointChanger = 1;
        _indexPoint = 0;
        _stayTime = 0;
    }

    void FixedUpdate()
    {
        if (_arrayPoints.Length > 0)
        {
            if (isMove)
            {
                Move();
            } else
            {
                GetNextPoint();
            }
        }
    }

    private void Move()
    {
        Transform transPoint = _nowPoint.transform;
        if (Vector3.Distance(transPoint.position, transform.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, transPoint.position, moveSpeed * Time.deltaTime);
            Rotate(transPoint.position);
        } else
        {
            isMove = false;
            _stayTime = Time.time + _nowPoint.GetStayTime();
        }
    }

    private void Rotate(Vector3 point)
    {
        Vector3 lookPoint = (point - transform.position).normalized;
        float pointAngle = 90 - Mathf.Atan2(lookPoint.x, lookPoint.x) * Mathf.Rad2Deg;

        float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, pointAngle, rotationSpeed);
        transform.eulerAngles = Vector3.up * angle;
    }

    private void GetNextPoint()
    {
        if (Time.time > _stayTime)
        {
            _indexPoint += _pointChanger;
            _nowPoint = _arrayPoints[_indexPoint];
            isMove = true;

            if (!staticSpeed)
                moveSpeed = _nowPoint.GetSpeed();

            if (_indexPoint == _arrayPoints.Length - 1 || _indexPoint == 0)
                _pointChanger = -_pointChanger;
        }
    }
}
