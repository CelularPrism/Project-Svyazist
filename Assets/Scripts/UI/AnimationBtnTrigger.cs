using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationBtnTrigger : MonoBehaviour
{
    [SerializeField] private Button[] buttons;

    public void EnableButtons()
    {
        foreach (Button btn in buttons)
        {
            btn.enabled = true;
        }
    }

    public void DisableButtons()
    {
        foreach (Button btn in buttons)
        {
            btn.enabled = false;
        }
    }
}
