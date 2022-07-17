using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Obstacle : AbstractItemObstacle
{
    [Header("Thought")]
    [SerializeField] private string key = "";
    [SerializeField] private float time = 0.1f;
    [SerializeField] private ThoughtsManager manager;
    [SerializeField] private int _sceneIndex = -1;
    [SerializeField] private Movement movement;
    [SerializeField] private LoadSceneMode mode;
    [SerializeField] private Collider[] colliders;

    public string nameItem;

    public override void Use(AbstractInteraction ai)
    {
        base.Use(ai);
       

   /*     foreach(Collider col in colliders)
        {
            col.enabled = false;
        }*/

        gameObject.SetActive(false);
        
        if (_sceneIndex > -1)
        {
         //   movement.SetIsMove(false);
            SceneManager.LoadScene(_sceneIndex, mode);
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(_sceneIndex));

        }
    }

    public void sayHelp()
    {
        string text = "";
        text = LocalisationSystem.GetLocalisedValue(key);
        manager.EnableThought(text, time);
    }

}
