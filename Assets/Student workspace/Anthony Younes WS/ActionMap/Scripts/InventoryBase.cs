using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnthonyY
{
    public abstract class InventoryBase : MonoBehaviour,IInventoryItems
    {
        //creating a list of inventory Items and getting its info
        public List<IInventoryItems> inventoryItems;
        [TextArea]
        public string inventoryName;
        public Sprite objectImage { get; }

        public bool pickedUp;

        public Event itemAddedEvent;

        public string objectName
        {
            get { return inventoryName;}
        }

        public virtual void OnPickUp()
        {
            throw new System.NotImplementedException();
        }

        public virtual void AddItem(IInventoryItems item)
        {
            
        }
    }
 
}
