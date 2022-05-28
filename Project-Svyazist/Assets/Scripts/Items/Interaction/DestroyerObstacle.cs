using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerObstacle : AbstractInteraction
{
    Item _item;
    public override void Awake()
    {
        base.Awake();
        _inputActions.Player.GetItem.performed += perf => DestroyObstacle();
    }

    private void DestroyObstacle()
    {
        if (_object != null)
        {
            _item = (Item)_playerInventory.GetItem(_object);
            if (_item != null)
            {
                _object.Use();
            }
        }
    }
}
