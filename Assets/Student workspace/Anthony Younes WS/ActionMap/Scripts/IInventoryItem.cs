using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class IInventoryItem: MonoBehaviour
{
    string name { get; }
    string description { get; }

    public virtual void OnPickUp()
    {
        
    }

    public virtual void OnActivate()
    {
        
    }

    public virtual void OnDeActivate()
    {
        
    }

    public GameObject go;
}

//testing
//toggle, increase integers
//seperate tests to another script
