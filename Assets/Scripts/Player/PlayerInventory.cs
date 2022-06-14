using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private PlayerAnimatorMovement _playerAnimatorMovement;

    private Dictionary<int, Sprite> _dictItems;

    private void Start()
    {
        _dictItems = new Dictionary<int, Sprite>();
    }

    public bool GetItem(int obstacle)
    {
        if (_dictItems.ContainsKey(obstacle))
        {
            _playerAnimatorMovement.UseItem();
            _dictItems.Remove(obstacle);
            inventoryUI.DeleteItem(obstacle);
            return true;
        }

        return false;
    }

    public Sprite[] GetAllItems()
    {
        int count = _dictItems.Count;
        Sprite[] array = new Sprite[count];
        _dictItems.Values.CopyTo(array, 0);

        return array;
    }

    public void SetItem(AbstractItemObstacle item)
    {
        _playerAnimatorMovement.GetItem();
        _dictItems[item.key] = item.spriteItem;
        inventoryUI.InsertItem(item);
    }
}
