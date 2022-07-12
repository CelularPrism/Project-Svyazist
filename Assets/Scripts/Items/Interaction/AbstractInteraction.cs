using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(SphereCollider), typeof(PlayerInventory))]
public class AbstractInteraction : MonoBehaviour
{
    [SerializeField] private int mask;
    [SerializeField] protected GameObject ButtonsCue;

    protected PlayerAction _inputActions;
    protected PlayerInventory _playerInventory;

    protected AbstractItemObstacle _object;

    protected bool _ButtonUse = false;

    public GameObject ButtonF
    {
        get { return ButtonsCue;  }
    }
    public bool ButtonUse
    {
        get { return ButtonsCue; }
        set { _ButtonUse = value; }
    }
    public virtual void Awake()
    {
        _inputActions = new PlayerAction();

        _playerInventory = GetComponent<PlayerInventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == mask)
        {
            _object = other.gameObject.GetComponent<AbstractItemObstacle>();
            if (!_ButtonUse && _object.enabled)
            {
                _inputActions.Enable();
                ButtonsCue.SetActive(true);
                //_ButtonUse = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == mask)
        {
            _object = null;
            _inputActions.Disable();
            ButtonsCue.SetActive(false);
        }
    }
}
