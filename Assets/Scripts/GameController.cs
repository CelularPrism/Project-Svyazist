using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //It is necessary to add dead animation
    [SerializeField] private PlayerAnimatorMovement _playerAnimatorMovement;
    [SerializeField] private Movement movement;
    public void Dead()
    {
        _playerAnimatorMovement.SetDeathFromEnemy();
        Debug.Log("Dead");
        movement.SetIsMove(false);
        Invoke("ReloadScene", 10f);
    }
    public void DeadFromMine()
    {
        _playerAnimatorMovement.SetDeathFromMine();
        Invoke("ReloadScene", 10f);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Application.Quit();
    }
}
