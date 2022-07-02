using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    [SerializeField] private DogSearching _dogSearching;

    [SerializeField] private Rigidbody _dogRigidBody;

    [SerializeField] private DogAnimator _dogAnimator;

    private float _movingDistance = 1.6f;
    private float _searchingDistanceZ = 0.5f;
    private float _moveDistance = 0.7f;

    private float _speed = 1.5f;

    private void Awake()
    {
       // _dogRigidBody = GetComponent<Rigidbody>();
       // _dogSearching = GetComponent<DogSearching>();
        _dogAnimator = GetComponentInChildren<DogAnimator>();
    }

    private void FixedUpdate()
    {
        if (!_dogSearching.IsSearching)
        {
            if (Vector3.Distance(_playerTransform.position, transform.position) > _movingDistance)
            {
                Move(_playerTransform.position);
                Rotate(_playerTransform.position);
            }
            else
                _dogAnimator.SitDown();
        }
        else 
        {
            Move(_dogSearching.PositionMine);
            Rotate(_dogSearching.PositionMine);

            if (Vector3.Distance(_dogSearching.PositionMine, transform.position) < _moveDistance)
            {
                _dogAnimator.Search();
                if (_dogSearching.IsMoving)
                    _dogAnimator.Find();
                _dogSearching.IsMoving = false;
                _dogSearching.TurnOffCollider();
            }

            if ((transform.position.z - _playerTransform.position.z) < _searchingDistanceZ && !_dogSearching.IsMoving)
            {
                _dogSearching.IsSearching = false;
            }
        }
    }
    private void Move(Vector3 targetPosition)
    {
        Vector3 newTransform = targetPosition - transform.position;
        newTransform.y = 0;

        _dogRigidBody.MovePosition(transform.position + (newTransform * _speed * Time.fixedDeltaTime));

        _dogAnimator.Move();
    }

    private void Rotate(Vector3 targetPosition)
    {
        Vector3 newTransform = (targetPosition - transform.GetChild(0).position);
        newTransform.y = 0;

        Quaternion lookRotation = Quaternion.LookRotation(newTransform);

        Vector3 lookEuler = lookRotation.eulerAngles;
        lookEuler.y += 60f;

        lookRotation = Quaternion.Euler(lookEuler);

        transform.GetChild(0).rotation = (lookRotation);
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
