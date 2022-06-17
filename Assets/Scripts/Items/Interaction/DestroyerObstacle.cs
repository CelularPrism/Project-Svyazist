using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerObstacle : AbstractInteraction
{
    bool _destroy;
    public override void Awake()
    {
        base.Awake();
        _inputActions.Player.GetItem.performed += perf => DestroyObstacle();
    }

    private void DestroyObstacle()
    {
        if (_object != null)
        {
            _destroy = _playerInventory.GetItem(_object.key);
            if (_destroy)
            {
                _object.Use(this);
            }
        }
    }
}
