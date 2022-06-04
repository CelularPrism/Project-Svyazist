using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<int> _listItems;

    private void Start()
    {
        _listItems = new List<int>();
    }

    public bool GetItem(int obstacleKey)
    {
        bool _item = false;

        foreach (int i in _listItems)
        {
            if (i == obstacleKey)
            {
                _item = true;
                _listItems.Remove(i);
                break;
            }
        }

        return _item;
    }

    public void SetItem(int itemKey)
    {
        _listItems.Add(itemKey);
    }
}
