using System;
using System.Collections;
using System.Collections.Generic;
using AnthonyY;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class InventoryControl : MonoBehaviour
{
    public InventoryTestControls inventoryControls;
    public Inventory items;

    // Start is called before the first frame update
    void Awake()
    {
        inventoryControls = new InventoryTestControls();
        inventoryControls.Inventory.Enable();
        inventoryControls.Inventory.Weapon.performed += WeaponSelect;
        inventoryControls.Inventory.PowerUp.performed += PowerUpUsed;
        inventoryControls.Inventory.Ability.performed += UseAbility;
    }
    

    private void OnDestroy()
    {
        inventoryControls.Inventory.Weapon.performed -= WeaponSelect;
        inventoryControls.Inventory.PowerUp.performed -= PowerUpUsed;
        inventoryControls.Inventory.Ability.performed -= UseAbility;
    }

    private void WeaponSelect(InputAction.CallbackContext obj)
    {
        Debug.Log("Weapon Selected");
    }
    private void PowerUpUsed(InputAction.CallbackContext obj)
    {
        Debug.Log("PowerUp Used"); 
        items.inventoryItems[0].OnPickUp();
        items.inventoryItems[0].OnActivate();
    }
    private void UseAbility(InputAction.CallbackContext obj)
    {
        Debug.Log("Ability Used");
      
    }
   
    
}
