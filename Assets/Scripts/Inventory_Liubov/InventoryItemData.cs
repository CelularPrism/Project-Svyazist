using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Inventory Item", menuName = "Inventory Item Data", order = 51)]
public class InventoryItemData : ScriptableObject
{
    [SerializeField]
    [Tooltip("Image of inventory item for UI")] private Sprite _inventoryItemImage;

    [SerializeField]
    [Tooltip("ID of inventory item for obstacle")] private int _inventoryItemID;

    [SerializeField]
    [Tooltip("The layer mask of inventory item for obstacle")] private LayerMask _inventoryItemMask;

    public int GetKey
    {
        get { return _inventoryItemID; }
    }
}
