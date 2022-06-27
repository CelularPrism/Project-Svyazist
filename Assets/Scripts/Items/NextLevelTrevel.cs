using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrevel : AbstractItemObstacle
{
    [SerializeField] private int _sceneIndex = -1;
    [SerializeField] private Movement movement;
    [SerializeField] private LoadSceneMode mode;


    public override void Use(AbstractInteraction ai)
    {
        gameObject.SetActive(false);
        if (_sceneIndex > -1)
        {
            SceneManager.LoadScene(_sceneIndex, mode);
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(_sceneIndex));

        }
    }

}
