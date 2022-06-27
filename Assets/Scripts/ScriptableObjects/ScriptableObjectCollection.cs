using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Collection", menuName = "ScriptableObjects/Collection", order = 1)]
public class ScriptableObjectCollection : ScriptableObject
{
    public string Name;
    public Sprite image2D;
    public string Text;
}
