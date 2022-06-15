using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartPoint : MonoBehaviour
{
    [SerializeField] private bool _isMines;
    [SerializeField] private bool _isChecked;
    [SerializeField] private int _maskPlayer;

    private BoxCollider _pointColider;
    private Transform _pointTransform;

    public bool IsMine
    {
        get { return _isMines; }
    }
    public bool IsChecked
    {
        get { return _isChecked; }
        set { _isChecked = value; }
    }
    public Vector3 PointPosition
    {
        get 
        {
            Debug.Log(transform.position);
            return transform.position; 
        }
    }
    private void Awake()
    {
        _pointColider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isMines && other.gameObject.tag == "Player")
        {
            Debug.Log("Main Character is dead");
            //call method for death main character with animation
        }
    }
}
