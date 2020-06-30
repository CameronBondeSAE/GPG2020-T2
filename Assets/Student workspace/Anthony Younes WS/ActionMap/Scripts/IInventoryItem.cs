using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItem
{
    string name { get; }
    string description { get; }
    void OnPickUp();
    void OnActivate();
}
