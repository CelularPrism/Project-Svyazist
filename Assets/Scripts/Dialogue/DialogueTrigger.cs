using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual cue")]
    [SerializeField] private GameObject visualCue;
    [SerializeField] private int playerLayer;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool _playerInRange;

    private void Awake()
    {
        _playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update()
    {
        if (_playerInRange)
            visualCue.SetActive(true);
        else
            visualCue.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == playerLayer)
            _playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == playerLayer)
            _playerInRange = false;
    }
}
