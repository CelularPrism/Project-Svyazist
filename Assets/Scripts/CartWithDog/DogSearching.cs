using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DogSearching : MonoBehaviour
{
    [SerializeField] private bool _isSearching;
    [SerializeField] private bool _isMoving;
    [SerializeField] private int _searchCount = 4;

    private FMOD.Studio.EventInstance Dog;

    private BoxCollider _dogCollider;

    private PlayerAction _inputActions;

    private Vector3 _positionMine;

    public bool IsSearching
    {
        get { return _isSearching; }
        set { _isSearching = value; }
    }
    public bool IsMoving
    {
        get { return _isMoving; }
        set { _isMoving = value; }
    }
    public Vector3 PositionMine
    {
        get
        {
            return _positionMine; 
        }
    }
    private void Awake()
    {
        _dogCollider = GetComponent<BoxCollider>();
        _dogCollider.enabled = false;

        _inputActions = new PlayerAction();
        _inputActions.Enable();

        _inputActions.Player.GetItem.performed += perf => StartSearch(perf);

        _positionMine = transform.position;
    }
    private void StartSearch(InputAction.CallbackContext perf)
    {
        if(!_isSearching && _searchCount >= 0)
        {
            Debug.Log("Start Search..." + Time.realtimeSinceStartup);

            // Stuff for FMOD Stuff for sound 
            Dog = FMODUnity.RuntimeManager.CreateInstance("event:/MiniGames/MineField/Dog");
            Dog.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            Dog.start();
            Dog.release();
            // END OF FMOD STUFF

            _dogCollider.enabled = true;
            _isSearching = true;
            _isMoving = true;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MapPoint")
        {
            if (!other.gameObject.GetComponent<CartPoint>().IsChecked && other.gameObject.GetComponent<CartPoint>().IsMine)
            {
                other.gameObject.GetComponent<CartPoint>().IsChecked = true;
                _positionMine = other.gameObject.GetComponent<CartPoint>().PointPosition;
                Debug.Log("Position Mine = " + _positionMine);
                
                _searchCount--;
                Debug.Log("searchCount" + _searchCount);
            }
        }
    }
    public void TurnOffCollider()
    {
        _dogCollider.enabled = false;
    }
}
