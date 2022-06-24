using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class AbstractItemObstacle : MonoBehaviour
{
    public int key;
    public Sprite spriteItem;
    public MeshRenderer[] _objectMeshRender;

    private void Awake()
    {

    }
    public virtual AbstractItemObstacle Get()
    {
        return this;
    }

    public virtual void Use(AbstractInteraction ai)
    {
        foreach(MeshRenderer mr in _objectMeshRender)
        {
            mr.enabled = false;
            ai.ButtonF.SetActive(false);
         //   ai.ButtonUse = true;
        }
        //Destroy(this.gameObject);
    }
}
