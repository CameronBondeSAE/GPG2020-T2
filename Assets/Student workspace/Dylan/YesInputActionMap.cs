// GENERATED AUTOMATICALLY FROM 'Assets/Student workspace/Dylan/YesInputActionMap.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @YesInputActionMap : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @YesInputActionMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""YesInputActionMap"",
    ""maps"": [
        {
            ""name"": ""AnActionMap"",
            ""id"": ""7c754890-85aa-483c-ab96-24a3990c0657"",
            ""actions"": [
                {
                    ""name"": ""DoAction"",
                    ""type"": ""Button"",
                    ""id"": ""9959bb9e-40d5-4651-b92c-057d80316efd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1b35e3bc-aa4a-486e-982c-be41b4ff54eb"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DoAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // AnActionMap
        m_AnActionMap = asset.FindActionMap("AnActionMap", throwIfNotFound: true);
        m_AnActionMap_DoAction = m_AnActionMap.FindAction("DoAction", throwIfNotFound: true);
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

    // AnActionMap
    private readonly InputActionMap m_AnActionMap;
    private IAnActionMapActions m_AnActionMapActionsCallbackInterface;
    private readonly InputAction m_AnActionMap_DoAction;
    public struct AnActionMapActions
    {
        private @YesInputActionMap m_Wrapper;
        public AnActionMapActions(@YesInputActionMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @DoAction => m_Wrapper.m_AnActionMap_DoAction;
        public InputActionMap Get() { return m_Wrapper.m_AnActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AnActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IAnActionMapActions instance)
        {
            if (m_Wrapper.m_AnActionMapActionsCallbackInterface != null)
            {
                @DoAction.started -= m_Wrapper.m_AnActionMapActionsCallbackInterface.OnDoAction;
                @DoAction.performed -= m_Wrapper.m_AnActionMapActionsCallbackInterface.OnDoAction;
                @DoAction.canceled -= m_Wrapper.m_AnActionMapActionsCallbackInterface.OnDoAction;
            }
            m_Wrapper.m_AnActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @DoAction.started += instance.OnDoAction;
                @DoAction.performed += instance.OnDoAction;
                @DoAction.canceled += instance.OnDoAction;
            }
        }
    }
    public AnActionMapActions @AnActionMap => new AnActionMapActions(this);
    public interface IAnActionMapActions
    {
        void OnDoAction(InputAction.CallbackContext context);
    }
}
