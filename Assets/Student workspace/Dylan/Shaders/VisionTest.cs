// GENERATED AUTOMATICALLY FROM 'Assets/Student workspace/Dylan/Shaders/VisionTest.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @VisionTest : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @VisionTest()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""VisionTest"",
    ""maps"": [
        {
            ""name"": ""Vision"",
            ""id"": ""926d1df9-6b1a-48c6-b0c7-590ceaa39b3d"",
            ""actions"": [
                {
                    ""name"": ""Ability"",
                    ""type"": ""Button"",
                    ""id"": ""6c0328cb-5059-49fb-b823-430672813c3e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1eb6fc92-481e-42f3-982e-b9b8f21ed8d8"",
                    ""path"": ""<Keyboard>/space"",
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
        // Vision
        m_Vision = asset.FindActionMap("Vision", throwIfNotFound: true);
        m_Vision_Ability = m_Vision.FindAction("Ability", throwIfNotFound: true);
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

    // Vision
    private readonly InputActionMap m_Vision;
    private IVisionActions m_VisionActionsCallbackInterface;
    private readonly InputAction m_Vision_Ability;
    public struct VisionActions
    {
        private @VisionTest m_Wrapper;
        public VisionActions(@VisionTest wrapper) { m_Wrapper = wrapper; }
        public InputAction @Ability => m_Wrapper.m_Vision_Ability;
        public InputActionMap Get() { return m_Wrapper.m_Vision; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(VisionActions set) { return set.Get(); }
        public void SetCallbacks(IVisionActions instance)
        {
            if (m_Wrapper.m_VisionActionsCallbackInterface != null)
            {
                @Ability.started -= m_Wrapper.m_VisionActionsCallbackInterface.OnAbility;
                @Ability.performed -= m_Wrapper.m_VisionActionsCallbackInterface.OnAbility;
                @Ability.canceled -= m_Wrapper.m_VisionActionsCallbackInterface.OnAbility;
            }
            m_Wrapper.m_VisionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Ability.started += instance.OnAbility;
                @Ability.performed += instance.OnAbility;
                @Ability.canceled += instance.OnAbility;
            }
        }
    }
    public VisionActions @Vision => new VisionActions(this);
    public interface IVisionActions
    {
        void OnAbility(InputAction.CallbackContext context);
    }
}
