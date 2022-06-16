using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //It is necessary to add dead animation
    //[SerializeField] private PlayerAnimatorMovement _playerAnimatorMovement;
    public void Dead()
    {
        //_playerAnimatorMovement.SetDeathFromEnemy();
        Debug.Log("Dead");
    }
    /*public void DeadFromMine()
    {
        _playerAnimatorMovement.SetDeathFromMine();
    }*/
}
