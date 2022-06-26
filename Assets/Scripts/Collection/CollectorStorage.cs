using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorStorage : MonoBehaviour
{
    private List<ScriptableObjectCollection> collections = new List<ScriptableObjectCollection>();
    public void SetCollection(CollectionItem collection)
    {
        collections.Add(collection.collection);
    }

    public string[] GetCollectionNames()
    {
        string[] arrayStr = new string[collections.Count];
        for (int i = 0; i < collections.Count; i++)
        {
            arrayStr[i] = collections[i].Name;
        }

        return arrayStr;
    }

    public ScriptableObjectCollection GetCollection(int num)
    {
        return collections[num];
    }
}
