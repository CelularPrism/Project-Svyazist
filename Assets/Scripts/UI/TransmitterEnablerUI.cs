using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmitterEnablerUI : MonoBehaviour
{
    [SerializeField] private TransmitterDistance transmitter;
    [SerializeField] private GameObject enabledTransmitter;
    [SerializeField] private GameObject disabledTransmitter;

    private void Update()
    {
        if (transmitter.GetState())
        {
            enabledTransmitter.SetActive(true);
            disabledTransmitter.SetActive(false);
        } else 
        {
            enabledTransmitter.SetActive(false);
            disabledTransmitter.SetActive(true);
        }
    }
}
