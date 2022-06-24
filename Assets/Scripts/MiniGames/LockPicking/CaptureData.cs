using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CaptureData : MonoBehaviour
{
    [SerializeField] private Image[] _detectionZones;
    [SerializeField] private float _sliderSpeed;
    [SerializeField] private int _previousSceneIndex;    
    [SerializeField] private int _currentSceneIndex;

    private BoxCollider2D _currentDetectionZoneCollider;

    private float _leftSize;
    private float _rightSize;

    private int _currentIndex;

  
    public float RightSize
    {
        get { return _rightSize; }

    }
    public float LeftSize
    {
        get { return _leftSize; }
    }
    public float SliderSpeed
    {
        get { return _sliderSpeed; }
    }   
    public int CurrentIndex
    {
        get { return _currentIndex; }
        set
        {
            _currentIndex = value;
        }
    }
    private void Start()
    {
        //_previousSceneName = Scene.name; it is necessary to specify the name of previous scene
    }
    public void SetNextDetectionZones()
    {
        if (CurrentIndex >= _detectionZones.Length)
            ReturnPreviousScene(); //it is necessary to load previous scene
        else
        {
            for (int i = 0; i < _detectionZones.Length; i++)
            {
                if (CurrentIndex == i)
                {
                    _detectionZones[i].gameObject.SetActive(true);
                    _currentDetectionZoneCollider = _detectionZones[i].GetComponent<BoxCollider2D>();

                    _rightSize = _detectionZones[i].GetComponent<RectTransform>().anchoredPosition3D.x +
                        (_currentDetectionZoneCollider.size.x / 2) * _detectionZones[i].transform.localScale.x;
                    _leftSize = _detectionZones[i].GetComponent<RectTransform>().anchoredPosition3D.x -
                        (_currentDetectionZoneCollider.size.x / 2) * _detectionZones[i].transform.localScale.x;
                }
                else
                    _detectionZones[i].gameObject.SetActive(false);
            }
        }
    }

    private void ReturnPreviousScene()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(_previousSceneIndex));
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByBuildIndex(_currentSceneIndex));
    }
}
