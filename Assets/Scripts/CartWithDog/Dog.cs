using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    [SerializeField] private DogSearching _dogSearching;

    private Rigidbody _dogRigidBody;

    //private Vector3 _movingDistance = new Vector3(0.5f, 0f, 0.5f);
    private float _movingDistance = 1.4f;
    private float _searchingDistanceZ = 0.5f;
    private float _moveDistance = 0.7f;

    private float _speed = 1.5f;

    private void Awake()
    {
        _dogRigidBody = GetComponent<Rigidbody>();
        _dogSearching = GetComponent<DogSearching>();
    }

    private void FixedUpdate()
    {
        if (!_dogSearching.IsSearching)
        {
            Vector3 newTransform = _playerTransform.position - transform.position;
            newTransform.y = 0;

            if (Vector3.Distance(_playerTransform.position, transform.position) > _movingDistance)
            {
                _dogRigidBody.MovePosition(transform.position + (newTransform * _speed * Time.fixedDeltaTime));
            }


            /*Vector3 newTransformNormalized = newTransform.normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(newTransformNormalized.x, 0, newTransformNormalized.z));
            _dogRigidBody.MoveRotation(Quaternion.Inverse(lookRotation)); //invert Quaternion*/
        }
        else 
        {
            Vector3 newTransform = _dogSearching.PositionMine - transform.position;
            newTransform.y = 0;

            _dogRigidBody.MovePosition(transform.position + (newTransform * _speed * Time.fixedDeltaTime));

            if (Vector3.Distance(_dogSearching.PositionMine, transform.position) < _moveDistance)
            {
                _dogSearching.IsMoving = false;
            }

            if ((transform.position.z - _playerTransform.position.z) < _searchingDistanceZ && !_dogSearching.IsMoving)
            {
                Debug.Log("! "+ _dogSearching.PositionMine);
                _dogSearching.IsSearching = false;
            }
        }
    }

   /* private void OnTriggerEnter(Collider other)
    {
        if (!_neighbourMapPoint.Contains(other.gameObject) && other.gameObject.tag == "MapPoint")
        {
            _neighbourMapPoint.Add(other.gameObject);
            if (other.gameObject.GetComponent<CartPoint>().IsMine)
            {
                _numMine++;
                ShowMine(other.gameObject.GetComponent<CartPoint>().ID, "enter");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (_neighbourMapPoint.Contains(other.gameObject) && other.gameObject.tag == "MapPoint")
        {
            _neighbourMapPoint.Remove(other.gameObject);
            if (other.gameObject.GetComponent<CartPoint>().IsMine)
            {
                _numMine--;
                ShowMine(other.gameObject.GetComponent<CartPoint>().ID, "exit");
            }
        }
    }
    private void ShowMine(int ID, string info)
    {
        Debug.Log("Count Of Mine " + _numMine + " Id " + ID + "Info" + info);
        //sound from dog or UI
    }*/
}
