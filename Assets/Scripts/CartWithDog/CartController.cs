using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartController : MonoBehaviour
{
    [SerializeField] private GameObject[] _points;

    //private Dictionary<int, GameObject> _pointsDictionary = new Dictionary<int, GameObject>();

    private void Awake()
    {
        /*foreach (GameObject point in _points)
        {
            _pointsDictionary.Add(point.GetComponent<CartPoint>().ID, point);
        }*/
    }
}
