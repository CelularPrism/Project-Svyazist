using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{
    [SerializeField] private int _previousScene;
    [SerializeField] private int _currentScene;
    [SerializeField] private int _nextScene;

    public void GoToTheNextScene()
    {
        Debug.Log("Nest scene");

    }
}
