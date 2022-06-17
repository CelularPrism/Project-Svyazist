using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Safe : MonoBehaviour
{
    [SerializeField] private int mask;
    [SerializeField] private int _buildIndex = 6;
    [SerializeField] protected GameObject ButtonsCue;

    protected PlayerAction _inputActions;

    public virtual void Awake()
    {
        _inputActions = new PlayerAction();
        _inputActions.Player.GetItem.performed += perf => LoadSafeScene();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == mask)
        {
             _inputActions.Enable();
             ButtonsCue.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == mask)
        {
            _inputActions.Disable();
            ButtonsCue.SetActive(false);
        }
    }
    private void LoadSafeScene()
    {
        SceneManager.LoadScene(_buildIndex);
    }
}
