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
        public string itemName;

        [TextArea]
        public string itemDescription;
        
        public Sprite objectImage { get; }

        public bool pickedUp;

        public Event itemAddedEvent;

        //How many items
        public int maxStack;
        public int currentStack;
        

        public string objectName
        {
            get { return itemName;}
        }

        public string objectDescription
        {
            get { return itemDescription; }
        }

        /// <summary>
/// Logic for what happens when picking up an item
/// </summary>
/// <exception cref="NotImplementedException"></exception>
        public virtual void OnPickUp()
        {
            throw new System.NotImplementedException();
        }

        public virtual void AddItem(IInventoryItems item)
        {
            
        }
    }
 
}
