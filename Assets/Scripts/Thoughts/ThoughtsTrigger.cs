using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class ThoughtsTrigger : MonoBehaviour
{
    [Header("Thought")]
    [SerializeField] private string key;
    [SerializeField] private float time;

    [Header("Layer Player")]
    [SerializeField] private int layer;

    private bool _isActive;

    private void Start()
    {
        //text = text.Replace("<br>", "\n");
        _isActive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isActive)
        {
            if (other.gameObject.layer == layer)
            {
                _isActive = false;
                ThoughtsManager thoughts = other.gameObject.GetComponent<ThoughtsManager>();

                string text = LocalisationSystem.GetLocalisedValue(key);
                Debug.Log(text);
                thoughts.EnableThought(text, time);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == layer)
        {
            ThoughtsManager thoughts = other.gameObject.GetComponent<ThoughtsManager>();
            //thoughts.DisableThought();
        }
    }
}
