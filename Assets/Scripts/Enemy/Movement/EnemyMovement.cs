using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Points")]
    [SerializeField] private PointEnemyMovement[] _arrayPoints;
    [SerializeField] private bool repeatPoints;

    [Header("Speed enemy")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private bool staticSpeed;

    //[SerializeField] private EnemyAnimator _enemyAnimator; 

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
                //_enemyAnimator.Move();
                Move();
            } else
            {
                if (_pointChanger != 0)
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

            if (_nowPoint.isLook)
                Rotate(_nowPoint.GetLookAtPoint());
            else
                Rotate(transPoint.position);
        } else
        {
            isMove = false;
            _stayTime = Time.time + _nowPoint.GetStayTime();
            //_enemyAnimator.Idle();
        }
    }

    private void Rotate(Vector3 point)
    {
        Quaternion rotTarget = Quaternion.LookRotation(point - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotTarget, rotationSpeed);
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
            {
                _pointChanger = -_pointChanger;

                if (!repeatPoints)
                    _pointChanger = 0;
            }
        }
    }
}
