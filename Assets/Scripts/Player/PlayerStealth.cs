using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStealth : MonoBehaviour
{
    public bool playerSit { get; private set; }

    [SerializeField] private Movement plrMovement;
    [SerializeField] private PlayerAnimatorMovement animator;
    //[SerializeField] private Transform playerCharacter;

    private PlayerAction _inputActions;
    private bool _inShelter;
    private Vector3 _scale;

    private void Start()
    {
        //_scale = playerCharacter.localScale;
        _inputActions = new PlayerAction();
        _inputActions.Enable();

        _inputActions.Player.SitDown.performed += perf => Sit();
        _inputActions.Player.SitDown.canceled += perf => Stand();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            _inShelter = true;
            /*playerCharacter.localScale = new Vector3(_scale.x, _scale.y / 2, _scale.z);
            _scale = playerCharacter.localScale;*/
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            _inShelter = false;
            /*playerCharacter.localScale = new Vector3(_scale.x, _scale.y * 2, _scale.z);
            _scale = playerCharacter.localScale;*/
        }
    }

    private void Sit()
    {
        animator.GoToSteath();
        plrMovement.SpeedSitDown(true);
    }

    private void Stand()
    {
        animator.GoToStand();
        plrMovement.SpeedSitDown(false);
    }
}
