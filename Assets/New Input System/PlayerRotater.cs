using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[RequireComponent(typeof(Movement))]
public class PlayerRotater : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;

    private bool _isMoveDown;

    private float _newY;
    private float _oldY;
    private float _deltaY;

    private void Awake()
    {
        _newY = 0f;
        _oldY = 0f;
    }
    public void Rotate(Vector3 inputValue)
    {
        _oldY = _newY;

        _deltaY = _cameraTransform.transform.rotation.eulerAngles.y;

        if (inputValue.z > 0)
        {
            _newY = 0f + _deltaY;
            _isMoveDown = false;
        }
        else if (inputValue.z < 0)
        {
            _newY = 180f + _deltaY;
            _isMoveDown = true;
        }

        if (inputValue.x > 0)
        {
            _newY = 90f + _deltaY;
        }
        else if (inputValue.x < 0)
        {
            _newY = 270f + _deltaY;
        }

        else if (inputValue.x == 0 && inputValue.z == 0)
        {
            _newY = _oldY;
        }

        transform.rotation = Quaternion.Euler(0f, _newY, 0f);
    }
}