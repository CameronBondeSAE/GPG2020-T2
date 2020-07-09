using System;
using System.Collections;
using System.Collections.Generic;
using AnthonY;
using AnthonyY;
using UnityEngine;
using UnityEngine.Analytics;

public class InventoryTesting : MonoBehaviour
{
    public Inventory inventory;
    public HealthPickUp healthPickUpTest;
    public InventoryControl InventoryControl;

    void Start()
    {
        Activation();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Collider>())
        {
            foreach (IInventoryItem item in inventory.items)
            {
                item.OnPickUp();
            }
        }
    }

    //A QUICK HACK FOR TESTING
    private void Activation()
    {
        if (inventory != null)
        {
            inventory.items.Add(healthPickUpTest);
            inventory.items[0].OnActivate();
        }
    }


    void OnGUI()
    {
        foreach (IInventoryItem item in inventory.items)
        {
            if (GUILayout.Button(item.name))
            {
                item.OnActivate();
            }
        }
    }
}


