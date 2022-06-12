using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject prefabInventoryItem;

    void FixedUpdate()
    {

    }

    public void DeleteItem(int key)
    {
        foreach (Transform child in transform)
        {
            AbstractItemObstacle item = child.gameObject.GetComponent<AbstractItemObstacle>();
            if (item.key == key)
            {
                Destroy(child.gameObject);
                return;
            }
        }
    }

    public void InsertItem(AbstractItemObstacle item)
    {
        GameObject gameObject = Instantiate(prefabInventoryItem, transform);
        gameObject.GetComponent<Item>().key = item.key;
        gameObject.GetComponent<Item>().spriteItem = item.spriteItem;

        gameObject.GetComponent<Image>().sprite = item.spriteItem;
    }
}
