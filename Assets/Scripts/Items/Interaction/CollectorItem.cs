using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CollectorItem: AbstractInteraction
{
    public override void Awake()
    {
        base.Awake();
        _inputActions.Player.GetItem.performed += perf => GetItem();
    }

    private void GetItem()
    {
        if (_object != null)
        {
            _playerInventory.SetItem(_object);
            _object.Use();
        }
    }
}
