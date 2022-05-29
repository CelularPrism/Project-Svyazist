using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStealth : MonoBehaviour
{
    [SerializeField] private Transform playerCharacter;
    private Vector3 _scale;

    private void Start()
    {
        _scale = playerCharacter.localScale;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Debug.Log("Sit down");
            playerCharacter.localScale = new Vector3(_scale.x, _scale.y / 2, _scale.z);
            _scale = playerCharacter.localScale;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Debug.Log("Sit down");
            playerCharacter.localScale = new Vector3(_scale.x, _scale.y * 2, _scale.z);
            _scale = playerCharacter.localScale;
        }
    }
}
