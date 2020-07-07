using System;
using System.Collections;
using System.Collections.Generic;
using AnthonY;
using AnthonyY;
using UnityEngine;

public class InventoryTesting : MonoBehaviour
{
    public Inventory inventory;
    
    public HealthPickUp healthPickUpTest;
    public InventoryControl InventoryControl;
    
    void Awake()
    {
        Tests(); 
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Collider>())
        {
            inventory.items[0].OnPickUp();
           
        }
    }
    //A QUICK HACK FOR TESTING
    private void Tests()
    {
        inventory.items.Add(healthPickUpTest);
        inventory.items[0].OnActivate();

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
