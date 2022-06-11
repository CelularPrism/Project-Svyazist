using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class AbstractItemObstacle : MonoBehaviour
{
    public int key;
    public ScriptableObjectItem SOItem;
    public virtual AbstractItemObstacle Get()
    {
        return this;
    }

    public virtual void Use()
    {
        Destroy(this.gameObject);
    }
}
