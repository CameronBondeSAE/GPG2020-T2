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
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Collider>().)
    }
    //A QUICK HACK FOR TESTING
    private void Tests()
    {
        inventory.items.Add(healthPickUpTest);
        inventory.items[0].OnPickUp();
        inventory.items[0].OnActivate();
    }

}
