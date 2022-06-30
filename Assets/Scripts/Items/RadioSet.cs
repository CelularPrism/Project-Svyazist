using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioSet : AbstractItemObstacle
{
    [SerializeField] private GameObject _panelTransmiterUI;
    [SerializeField] private GameObject _playerTransmiter;
    [SerializeField] private GameObject _mainTransmiter;

    [SerializeField] private BoxCollider _radioSetTriggerCollider;
    public override void Use(AbstractInteraction ai)
    {
        base.Use(ai);
        _radioSetTriggerCollider.enabled = false;
        SetTransmiter();
    }

    private void SetTransmiter()
    {
        _panelTransmiterUI.SetActive(true);

        _playerTransmiter.SetActive(true);

        _mainTransmiter.SetActive(true);
    }
}
