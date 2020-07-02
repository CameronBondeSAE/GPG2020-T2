

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace AnthonyY
{
    public class @InventoryTestControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InventoryTestControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InventoryTestControls"",
    ""maps"": [
        {
            ""name"": ""Inventory"",
            ""id"": ""20272cc9-9b5b-41c0-a381-1b7d135c0803"",
            ""actions"": [
                {
                    ""name"": ""Weapon"",
                    ""type"": ""Button"",
                    ""id"": ""c2fdb32f-4d16-44aa-8162-6360e4d5b3fa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PowerUp"",
                    ""type"": ""Button"",
                    ""id"": ""2732a2a5-acaa-4159-bc64-3ba8d60e9fc0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ability"",
                    ""type"": ""Button"",
                    ""id"": ""351718c0-e6d3-462a-a520-fafcc8941879"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""645bc009-8c1e-4465-864f-9f1dc5494aeb"",
                    ""path"": ""<Keyboard>/#(1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Weapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7cef4003-08c6-4905-94ad-2b12feccc398"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PowerUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13c1ffd6-3008-419c-8956-e61795260311"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Inventory
            m_Inventory = asset.FindActionMap("Inventory", throwIfNotFound: true);
            m_Inventory_Weapon = m_Inventory.FindAction("Weapon", throwIfNotFound: true);
            m_Inventory_PowerUp = m_Inventory.FindAction("PowerUp", throwIfNotFound: true);
            m_Inventory_Ability = m_Inventory.FindAction("Ability", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        // Inventory
        private readonly InputActionMap m_Inventory;
        private IInventoryActions m_InventoryActionsCallbackInterface;
        private readonly InputAction m_Inventory_Weapon;
        private readonly InputAction m_Inventory_PowerUp;
        private readonly InputAction m_Inventory_Ability;
        public struct InventoryActions
        {
            private @InventoryTestControls m_Wrapper;
            public InventoryActions(@InventoryTestControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Weapon => m_Wrapper.m_Inventory_Weapon;
            public InputAction @PowerUp => m_Wrapper.m_Inventory_PowerUp;
            public InputAction @Ability => m_Wrapper.m_Inventory_Ability;
            public InputActionMap Get() { return m_Wrapper.m_Inventory; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(InventoryActions set) { return set.Get(); }
            public void SetCallbacks(IInventoryActions instance)
            {
                if (m_Wrapper.m_InventoryActionsCallbackInterface != null)
                {
                    @Weapon.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnWeapon;
                    @Weapon.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnWeapon;
                    @Weapon.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnWeapon;
                    @PowerUp.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnPowerUp;
                    @PowerUp.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnPowerUp;
                    @PowerUp.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnPowerUp;
                    @Ability.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnAbility;
                    @Ability.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnAbility;
                    @Ability.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnAbility;
                }
                m_Wrapper.m_InventoryActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Weapon.started += instance.OnWeapon;
                    @Weapon.performed += instance.OnWeapon;
                    @Weapon.canceled += instance.OnWeapon;
                    @PowerUp.started += instance.OnPowerUp;
                    @PowerUp.performed += instance.OnPowerUp;
                    @PowerUp.canceled += instance.OnPowerUp;
                    @Ability.started += instance.OnAbility;
                    @Ability.performed += instance.OnAbility;
                    @Ability.canceled += instance.OnAbility;
                }
            }
        }
        public InventoryActions @Inventory => new InventoryActions(this);
        public interface IInventoryActions
        {
            void OnWeapon(InputAction.CallbackContext context);
            void OnPowerUp(InputAction.CallbackContext context);
            void OnAbility(InputAction.CallbackContext context);
        }
    }
}
