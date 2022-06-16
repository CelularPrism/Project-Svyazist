using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransmitterUI : MonoBehaviour
{
    [SerializeField] private Image stateImage;
    [SerializeField] private TransmitterDistance transmitter;
    
    [SerializeField] private float[] stateOfDistance;
    [SerializeField] private Sprite[] stateSprites;

    private int _index;
    private int _prevIndex;

    private int _indexSprite;

    void Start()
    {
        _index = 1;
        _prevIndex = 0;
    }

    void Update()
    {
        if (transmitter.GetState())
        {
            CheckDistance();
            stateImage.sprite = stateSprites[_prevIndex];
        }
    }

    private void CheckDistance()
    {
        float distance = transmitter.GetDistance();

        if (distance < stateOfDistance[_index])
        {
            _index++;
            if (_index >= stateOfDistance.Length)
            {
                _index = stateOfDistance.Length - 1;
            }

            _prevIndex = _index - 1;
        }

        if (distance > stateOfDistance[_prevIndex])
        {
            _prevIndex--;
            if (_prevIndex < 0)
            {
                _prevIndex = 0;
            }

            _index = _prevIndex + 1;
        }
        _indexSprite = _index;
    }
}
