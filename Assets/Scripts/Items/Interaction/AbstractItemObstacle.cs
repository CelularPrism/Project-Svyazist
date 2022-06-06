﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class AbstractItemObstacle : MonoBehaviour
{
    //may be interface
    public int key;
    public virtual AbstractItemObstacle Get()
    {
        return this;
    }

    public virtual void Use()
    {
        Destroy(this.gameObject);
    }
}
