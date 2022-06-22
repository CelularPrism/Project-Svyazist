//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.1.1
//     from Assets/New Input System/Menu.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @MenuAction : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MenuAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Menu"",
    ""maps"": [
        {
            ""name"": ""Menu"",
            ""id"": ""3e9e7b02-9ba6-4f44-b9e5-75889d9f3f29"",
            ""actions"": [
                {
                    ""name"": ""OpenClose"",
                    ""type"": ""Button"",
                    ""id"": ""69a4eb27-4fe0-431b-947d-16f11b3daed3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1f373fdf-d094-4056-9c97-3e59dca828e9"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenClose"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_OpenClose = m_Menu.FindAction("OpenClose", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_OpenClose;
    public struct MenuActions
    {
        private @MenuAction m_Wrapper;
        public MenuActions(@MenuAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @OpenClose => m_Wrapper.m_Menu_OpenClose;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @OpenClose.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnOpenClose;
                @OpenClose.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnOpenClose;
                @OpenClose.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnOpenClose;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @OpenClose.started += instance.OnOpenClose;
                @OpenClose.performed += instance.OnOpenClose;
                @OpenClose.canceled += instance.OnOpenClose;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    public interface IMenuActions
    {
        void OnOpenClose(InputAction.CallbackContext context);
    }
}
