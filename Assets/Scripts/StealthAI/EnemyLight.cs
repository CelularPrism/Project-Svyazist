using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLight : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float viewDistance;
    [SerializeField] private LayerMask viewMask;
    [SerializeField] private Light spotLight;
    [SerializeField] private Color defaultLightColor;

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
        } else
        {
            spotLight.color = defaultLightColor;
        }
    }

    private bool CanSeePlayer()
    {
        if (Vector3.Distance(transform.position, player.position) < viewDistance)
        {
            Vector3 dirPlayer = (player.position - transform.position).normalized;
            float angleBetweenEnemyPlayer = Vector3.Angle(transform.forward, dirPlayer);
            if (angleBetweenEnemyPlayer < _viewAngle / 2f)
            {
                if (!Physics.Linecast(transform.position, player.position, viewMask))
                {
                    return true;
                }
            }
        }
        return false;
    }
}
