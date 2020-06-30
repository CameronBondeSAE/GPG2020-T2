using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnthonyY;

namespace AnthonyY
{
    public class Inventory: MonoBehaviour
    {
        //creating a list of inventory Items and getting its info
        public List<IInventoryItem> inventoryItems = new List<IInventoryItem>();
    }
}
