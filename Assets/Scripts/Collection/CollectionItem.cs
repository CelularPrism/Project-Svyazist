using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionItem : AbstractItemObstacle
{
    public ScriptableObjectCollection collection { get; [SerializeField] private set; } 
}
