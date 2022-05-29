using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStealth : MonoBehaviour
{
    private bool _inShelter = false;

    public bool GetState()
    {
        return _inShelter;
    }

    public void SetState(bool state)
    {
        _inShelter = state;
    }
}
