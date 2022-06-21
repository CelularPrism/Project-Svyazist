using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThoughtsManager : MonoBehaviour
{
    [Header("Bubble")]
    [SerializeField] private GameObject bubbleThoughts;
    [Header("TextMeshPro")]
    [SerializeField] private TextMeshProUGUI textMesh;

    public void EnableThought(string text, float time)
    {
        textMesh.text = text;
        bubbleThoughts.SetActive(true);
        Invoke("DisableThought", time);
    }

    public void DisableThought()
    {
        bubbleThoughts.SetActive(false);
    }
}
