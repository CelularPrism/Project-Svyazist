using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class CollectorItem : MonoBehaviour
{
    [SerializeField] private int maskItem;
    private Item _item;

    private void FixedUpdate()
    {
        if (_item != null)
        {
            Debug.Log("Press F");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == maskItem)
        {
            Debug.Log("Item enter");
            _item = other.gameObject.GetComponent<Item>();
            //Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == maskItem)
        {
            Debug.Log("Item exit");
            _item = null;
        }
    }
}
