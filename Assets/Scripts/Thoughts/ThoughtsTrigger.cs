using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class ThoughtsTrigger : MonoBehaviour
{
    [Header("Thought")]
    [SerializeField] private string text;
    [SerializeField] private float time;

    [Header("Layer Player")]
    [SerializeField] private int layer;

    private void Start()
    {
        text = text.Replace("<br>", "\n");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == layer)
        {
            ThoughtsManager thoughts = other.gameObject.GetComponent<ThoughtsManager>();
            thoughts.EnableThought(text, time);
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
