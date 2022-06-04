﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(SphereCollider), typeof(PlayerInventory))]
public class AbstractInteraction : MonoBehaviour
{
    [SerializeField] private int mask;

    protected PlayerAction _inputActions;
    protected PlayerInventory _playerInventory;

    protected AbstractItemObstacle _object;

    public virtual void Awake()
    {
        _inputActions = new PlayerAction();
        _inputActions.Enable();

        _playerInventory = GetComponent<PlayerInventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == mask)
        {
            _object = other.gameObject.GetComponent<AbstractItemObstacle>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == mask)
        {
            _object = null;
        }
    }
}
