using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<AbstractItemObstacle> _listItems;

    private void Start()
    {
        _listItems = new List<AbstractItemObstacle>();
    }

    public AbstractItemObstacle GetItem(AbstractItemObstacle obstacle)
    {
        AbstractItemObstacle _item = null;

        foreach (AbstractItemObstacle i in _listItems)
        {
            if (i.key == obstacle.key)
            {
                _item = i;
                _listItems.Remove(_item);
                break;
            }
        }

        return _item;
    }

    public void SetItem(AbstractItemObstacle item)
    {
        _listItems.Add(item);
    }
}
