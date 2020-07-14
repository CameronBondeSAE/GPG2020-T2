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
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""3c023fe5-b210-4814-b0f9-bc2b89dfe368"",
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
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""3a6b450e-40cb-4eb0-84b5-75fb76286a4c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6f818563-20dd-4693-b702-0e90cd899808"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1391fa36-e0cf-4e5f-8889-e335a4f85594"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1d0e0ced-d5a6-42ca-b2d8-e500695c0f87"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2dfcb5e6-2d7b-4351-9309-aa711417e31c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // AnActionMap
        m_AnActionMap = asset.FindActionMap("AnActionMap", throwIfNotFound: true);
        m_AnActionMap_DoAction = m_AnActionMap.FindAction("DoAction", throwIfNotFound: true);
        m_AnActionMap_Move = m_AnActionMap.FindAction("Move", throwIfNotFound: true);
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
    private readonly InputAction m_AnActionMap_Move;
    public struct AnActionMapActions
    {
        private @YesInputActionMap m_Wrapper;
        public AnActionMapActions(@YesInputActionMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @DoAction => m_Wrapper.m_AnActionMap_DoAction;
        public InputAction @Move => m_Wrapper.m_AnActionMap_Move;
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
                @Move.started -= m_Wrapper.m_AnActionMapActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_AnActionMapActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_AnActionMapActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_AnActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @DoAction.started += instance.OnDoAction;
                @DoAction.performed += instance.OnDoAction;
                @DoAction.canceled += instance.OnDoAction;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public AnActionMapActions @AnActionMap => new AnActionMapActions(this);
    public interface IAnActionMapActions
    {
        void OnDoAction(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
}
