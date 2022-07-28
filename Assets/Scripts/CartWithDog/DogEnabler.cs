using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogEnabler : MonoBehaviour
{
    [SerializeField] private DialogueTrigger dialogueTrigger;
    [SerializeField] private Dog dog;
    [SerializeField] private GameObject dogSearching; //private DogSearching dofSearching;

    private bool _enabled;

    private void Awake()
    {
        _enabled = true;
    }

    private void FixedUpdate()
    {
        if (!dialogueTrigger._isActive && _enabled)
        {
            dog.enabled = true;
            dogSearching.SetActive(true); //this isn't work since dog (gameobject) is active from start of the level
            _enabled = false;
        }
    }
}
