using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerInventory : MonoBehaviour
{
    private List<int> _listItems;

    private void Start()
    {
        _listItems = new List<int>();
    }

    public bool GetItem(int obstacle)
    {
        bool _item = false;

        foreach (int i in _listItems)
        {
            if (i == obstacle)
            {
                _item = true;
                _listItems.Remove(i);
                break;
            }
        }

        return _item;
    }

    public void SetItem(int item)
    {
        _listItems.Add(item);
    }
}
