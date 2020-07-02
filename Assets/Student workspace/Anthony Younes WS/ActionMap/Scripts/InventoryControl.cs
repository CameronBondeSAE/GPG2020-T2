using System;
using System.Collections;
using System.Collections.Generic;
using AnthonyY;
using Mirror.Examples;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

namespace AnthonY
{
    public class InventoryControl : MonoBehaviour
    {
        public InventoryTestControls inventoryControls;
        public Inventory inventory;

        public HealthPickUp healthPickUpTest;

        // Start is called before the first frame update
        void Awake()
        {
            inventoryControls = new InventoryTestControls();
            inventoryControls.Inventory.Enable();
            inventoryControls.Inventory.Weapon.performed += WeaponSelect;
            inventoryControls.Inventory.PowerUp.performed += PowerUpUsed;
            inventoryControls.Inventory.Ability.performed += UseAbility;
            
        }

        void Start()
        {
            //Tests();
        }


        private void OnDestroy()
        {
            inventoryControls.Inventory.Weapon.performed -= WeaponSelect;
            inventoryControls.Inventory.PowerUp.performed -= PowerUpUsed;
            inventoryControls.Inventory.Ability.performed -= UseAbility;
        }
        
        //A QUICK HACK FOR TESTING
        /*private void Tests()
        {
            inventory.items.Add(healthPickUpTest);
            inventory.items[0].OnPickUp();
            inventory.items[0].OnActivate();
        }*/

        private void WeaponSelect(InputAction.CallbackContext obj)
        {
            Debug.Log("Weapon Selected");
        }
        private void PowerUpUsed(InputAction.CallbackContext obj)
        {
            Debug.Log("PowerUp Used");
        }
        private void UseAbility(InputAction.CallbackContext obj)
        {
            Debug.Log("Ability Used");
      
        }
   
    
    }
}

