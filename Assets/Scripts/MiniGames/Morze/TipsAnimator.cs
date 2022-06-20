using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsAnimator : MonoBehaviour
{
    [SerializeField] private TextMorzeData _textMorzeData;

    public void EndAnimation()
    {
        _textMorzeData.SetNewSymbol();
    }
}
