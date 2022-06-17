using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual cue")]
    [SerializeField] private GameObject visualCue;
    [SerializeField] private int playerLayer;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private Sprite sprite;

    private bool _playerInRange;
    private PlayerAction _inputActions;
    private bool _isActive;
    //private static bool _isActive;

    private void Awake()
    {
        _playerInRange = false;
        visualCue.SetActive(false);
        _inputActions = new PlayerAction();

        _inputActions.Player.GetItem.performed += pref =>
        {
            OpenDialogue();
        };
        _isActive = true;
    }

    private void Update()
    {
        /*if (_isActive)
        {
            //if (_playerInRange && !DialogueManager.GetInstance()._dialogueIsPlaying)
                //visualCue.SetActive(true);
            //else
                //visualCue.SetActive(false);
        }*/
    }

    private void OpenDialogue()
    {
        if(_isActive)
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON, sprite);
            visualCue.SetActive(false);
            _isActive = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == playerLayer && _isActive)
        {
            _inputActions.Enable();
            _playerInRange = true;
            visualCue.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == playerLayer && _isActive)
        {
            _inputActions.Disable();
            _playerInRange = false;
            visualCue.SetActive(false);
        }
    }
}
