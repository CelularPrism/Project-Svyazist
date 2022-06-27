using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CollectorStorage))]
public class CollectionCollector : AbstractInteraction
{
    private CollectorStorage _storage;

    public override void Awake()
    {
        base.Awake();
        _inputActions.Player.GetItem.performed += perf => GetCollection();
    }

    public void GetCollection()
    {
        CollectionItem item = (CollectionItem)_object;
        _storage.SetCollection(item);
    }
}
