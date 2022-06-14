using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private MorzeController _morzeController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _morzeController.LoseMatch();
    }
}
