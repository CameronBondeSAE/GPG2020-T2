// GENERATED AUTOMATICALLY FROM 'Assets/Project settings/GameControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""In Game"",
            ""id"": ""d74fd78b-596c-43c1-99a0-158dab2bc2ed"",
            ""actions"": [
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""cb0c1dc9-8b15-4ef4-92de-1fb9ea5c6aea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""5afdcd25-d92a-4d43-a029-fcfa8904ff0c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""df65d254-0cd0-4803-b340-6d023d4bdfcc"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""149ec3dd-b4b2-415a-a17c-ac16dd84bcbf"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9bdb1c70-f9cd-4917-9562-4d4cfeb80c08"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""e428e7dc-3233-43ec-918a-b24653de1922"",
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
                    ""id"": ""2c399529-1084-4182-b9a3-d9b184614bc1"",
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
                    ""id"": ""2e0dc459-87d7-4c77-9df1-4575a389b80f"",
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
                    ""id"": ""61de80f8-3ee8-4ba4-a2fe-48dbc4bdf8af"",
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
                    ""id"": ""fc8c9de8-b2bb-42e9-b2ba-c5c2932fee55"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""In Menu"",
            ""id"": ""4ad8d090-5bcb-4df7-a52e-746202cf8fbc"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""79d18eaf-3dce-4cee-88c5-f7d29294089e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0f666520-b422-4304-ba6f-de5bbee5546e"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // In Game
        m_InGame = asset.FindActionMap("In Game", throwIfNotFound: true);
        m_InGame_Fire = m_InGame.FindAction("Fire", throwIfNotFound: true);
        m_InGame_Move = m_InGame.FindAction("Move", throwIfNotFound: true);
        // In Menu
        m_InMenu = asset.FindActionMap("In Menu", throwIfNotFound: true);
        m_InMenu_Newaction = m_InMenu.FindAction("New action", throwIfNotFound: true);
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

    // In Game
    private readonly InputActionMap m_InGame;
    private IInGameActions m_InGameActionsCallbackInterface;
    private readonly InputAction m_InGame_Fire;
    private readonly InputAction m_InGame_Move;
    public struct InGameActions
    {
        private @GameControls m_Wrapper;
        public InGameActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fire => m_Wrapper.m_InGame_Fire;
        public InputAction @Move => m_Wrapper.m_InGame_Move;
        public InputActionMap Get() { return m_Wrapper.m_InGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InGameActions set) { return set.Get(); }
        public void SetCallbacks(IInGameActions instance)
        {
            if (m_Wrapper.m_InGameActionsCallbackInterface != null)
            {
                @Fire.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnFire;
                @Move.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_InGameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public InGameActions @InGame => new InGameActions(this);

    // In Menu
    private readonly InputActionMap m_InMenu;
    private IInMenuActions m_InMenuActionsCallbackInterface;
    private readonly InputAction m_InMenu_Newaction;
    public struct InMenuActions
    {
        private @GameControls m_Wrapper;
        public InMenuActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_InMenu_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_InMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InMenuActions set) { return set.Get(); }
        public void SetCallbacks(IInMenuActions instance)
        {
            if (m_Wrapper.m_InMenuActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_InMenuActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_InMenuActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_InMenuActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_InMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public InMenuActions @InMenu => new InMenuActions(this);
    public interface IInGameActions
    {
        void OnFire(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
    public interface IInMenuActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
