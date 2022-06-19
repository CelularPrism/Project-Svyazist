using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLight : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform lineCastPoint;
    [SerializeField] private float viewDistance;
    [SerializeField] private LayerMask viewMask;
    [SerializeField] private Light spotLight;
    [SerializeField] private Color defaultLightColor;

    [SerializeField] private EnemyAnimator _enemyAnimator; 

    private float _viewAngle;

    void Start()
    {
        _viewAngle = spotLight.spotAngle;   
    }

    void FixedUpdate()
    {
        if (CanSeePlayer())
        {
            player.GetComponent<PlayerStealthController>().Detected();
            spotLight.color = Color.red;
            _enemyAnimator.Detect();
            _enemyAnimator.Shoot();
        }
        else
        {
            spotLight.color = defaultLightColor;
        }
    }

    private bool CanSeePlayer()
    {
        if (Vector3.Distance(lineCastPoint.position, player.position) < viewDistance)
        {
            Vector3 dirPlayer = (player.position - lineCastPoint.position).normalized;
            float angleBetweenEnemyPlayer = Vector3.Angle(lineCastPoint.forward, dirPlayer);
            if (angleBetweenEnemyPlayer < _viewAngle / 2f -2f)
            {
                if (!Physics.Linecast(lineCastPoint.position, player.position, viewMask))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(lineCastPoint.position, player.position);
    }
}
