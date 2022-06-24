using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathImage : MonoBehaviour
{
    [SerializeField] private GameObject deathPanel;

    public void Death()
    {
        deathPanel.SetActive(true);
    }
}
