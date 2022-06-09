using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaptureData : MonoBehaviour
{
    [SerializeField] private float[] _sliderSpeed;

    [SerializeField] private GameObject[] _detectionZones;

    private BoxCollider _currentDetectionZoneCollider;

    private float _leftSize;
    private float _rightSize;

    private int _currentIndexDetectionZone;
    private int _currentIndexSliderSpeed;

    private string _previousSceneName; //It is necessary to store the name or index of the scene in the global data

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
        get { return _sliderSpeed[_currentIndexSliderSpeed]; }
    }
    public int CurrentIndexSliderSpeed
    {
        get { return _currentIndexSliderSpeed; }
        set
        {
            _currentIndexSliderSpeed = value;
        }
    }    
    public int CurrentIndexDetectionZone
    {
        get { return _currentIndexDetectionZone; }
        set
        {
            _currentIndexDetectionZone = value;
        }
    }
    private void Start()
    {
        //_previousSceneName = Scene.name; it is necessary to specify the scene name
    }
    public void SetNextDetectionZones()
    {
        if (CurrentIndexDetectionZone >= _detectionZones.Length - 1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else
        {
            for(int i = 0; i < _detectionZones.Length; i++)
            {
                if (CurrentIndexDetectionZone == i)
                {
                    _detectionZones[i].SetActive(true);
                    _currentDetectionZoneCollider = _detectionZones[i].GetComponent<BoxCollider>();

                    _rightSize = _detectionZones[i].transform.position.x + _currentDetectionZoneCollider.size.x * _detectionZones[i].transform.localScale.x;
                    _leftSize = _detectionZones[i].transform.position.x - _currentDetectionZoneCollider.size.x * _detectionZones[i].transform.localScale.x;
                }
                else
                    _detectionZones[i].SetActive(false);
            }
        }
    }
}
