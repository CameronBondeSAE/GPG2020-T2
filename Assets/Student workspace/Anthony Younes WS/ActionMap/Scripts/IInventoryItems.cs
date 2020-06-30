using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItems
{ 
        string objectName { get; } 
        void OnPickUp();
        Sprite  objectImage { get; }
}
