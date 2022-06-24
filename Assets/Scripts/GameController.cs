using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //It is necessary to add dead animation
    [SerializeField] private PlayerAnimatorMovement _playerAnimatorMovement;
    [SerializeField] private DeathImage deathImage;
    [SerializeField] private Movement movement;

    [SerializeField] private float time;
    public void Dead()
    {
        _playerAnimatorMovement.SetDeathFromEnemy();
        movement.SetIsMove(false);
        Invoke("ReloadScene", time);
    }
    public void DeadFromMine()
    {
        _playerAnimatorMovement.SetDeathFromMine();
        movement.SetIsMove(false);
        Invoke("ReloadScene", time);
    }

    private void ReloadScene()
    {
        deathImage.Death();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Application.Quit();
    }
}
