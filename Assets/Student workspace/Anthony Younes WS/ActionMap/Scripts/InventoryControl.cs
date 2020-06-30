﻿using System;
using System.Collections;
using System.Collections.Generic;
using AnthonyY;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class InventoryControl : InventoryBase,IInventoryItems
{
    public InventoryTestControls inventoryControls;
    private InputAction inventory;

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
    private void UseAbility(InputAction.CallbackContext obj)
    {
        Debug.Log("Ability Used\n");
    }
    
    private void WeaponSelect(InputAction.CallbackContext obj)
    {
        Debug.Log("Weapon Selected\n");
    }
    private void PowerUpUsed(InputAction.CallbackContext obj)
    {
        Debug.Log("PowerUp Used\n"); 
    }

    public override void AddItem(IInventoryItems item)
    {
        base.AddItem(item);
    }
}
