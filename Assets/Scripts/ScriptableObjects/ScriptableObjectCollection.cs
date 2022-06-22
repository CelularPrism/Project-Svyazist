using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Collection", menuName = "ScriptableObjects/Collection", order = 1)]
    public class Collection : ScriptableObject
    {
        public string Name;
        public Sprite image2D;
        public string Text;
    }
}
