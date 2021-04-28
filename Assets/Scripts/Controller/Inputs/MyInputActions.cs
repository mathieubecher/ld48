// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Controller/Inputs/MyInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MyInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MyInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MyInputActions"",
    ""maps"": [
        {
            ""name"": ""Base"",
            ""id"": ""15b64c66-37ea-4610-970e-c64bbabb8f7d"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""83f2190f-72b7-4f83-9489-6723f2680edd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Horizontal"",
                    ""type"": ""Value"",
                    ""id"": ""0351069a-8b61-430f-94a6-c3e5df568a5d"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""454dcb43-f304-4643-a042-94d211b8cd56"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Switch"",
                    ""type"": ""Button"",
                    ""id"": ""05867a15-6963-4614-b739-a72c8f21076e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AddTime"",
                    ""type"": ""Button"",
                    ""id"": ""d3e3cc49-682d-4150-92fc-6bed51b21608"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SubstractTime"",
                    ""type"": ""Button"",
                    ""id"": ""b51feed5-2c2a-4256-863a-cf78eb2ea8bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""34e1affb-1f09-43cc-ad1b-c3e038d75fe4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ef14b5f6-b60b-4d31-9218-a6759ea23b30"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""76f48c30-b611-40b6-acac-342e6f04d057"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""26f26653-df00-4d9c-9be8-35c929e49b8d"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""022b7f96-3c62-457c-895d-5cadc85eafe3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""17b9cf6a-78db-4821-89f4-0c19fd3086ae"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8258558c-cfa0-415c-9920-d2769f4cb3a1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""71e03b5a-0a98-43a6-98c1-46f900d0f5a0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6d88be1d-75d5-48ee-a3f1-77d0111c107f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""bd843037-d47e-4d06-8fd8-50ce381b8722"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f431b7f3-cd38-4c4d-bc0d-2d939fc3cc75"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5157d872-3bb4-48b0-b947-3d26680c67eb"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""532fada8-db39-4738-a92d-c38907ef927d"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""58c80a99-1e51-4976-8cbf-769fc6d1db5a"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36cad97f-9240-4c0d-b817-2d1a9741502c"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AddTime"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd9115dc-9400-4644-8fb0-0febf6508eb6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""AddTime"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a80f00ac-3985-4572-b408-5bece5d11aee"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SubstractTime"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""468b25de-b6dc-46bb-935b-008ab8a53299"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""SubstractTime"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89ed7b04-90fb-403c-b596-8268903074f8"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8862d2c8-c2f3-40b1-a2ae-1529dbd7e4d1"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Base
        m_Base = asset.FindActionMap("Base", throwIfNotFound: true);
        m_Base_Pause = m_Base.FindAction("Pause", throwIfNotFound: true);
        m_Base_Horizontal = m_Base.FindAction("Horizontal", throwIfNotFound: true);
        m_Base_Jump = m_Base.FindAction("Jump", throwIfNotFound: true);
        m_Base_Switch = m_Base.FindAction("Switch", throwIfNotFound: true);
        m_Base_AddTime = m_Base.FindAction("AddTime", throwIfNotFound: true);
        m_Base_SubstractTime = m_Base.FindAction("SubstractTime", throwIfNotFound: true);
        m_Base_Interact = m_Base.FindAction("Interact", throwIfNotFound: true);
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

    // Base
    private readonly InputActionMap m_Base;
    private IBaseActions m_BaseActionsCallbackInterface;
    private readonly InputAction m_Base_Pause;
    private readonly InputAction m_Base_Horizontal;
    private readonly InputAction m_Base_Jump;
    private readonly InputAction m_Base_Switch;
    private readonly InputAction m_Base_AddTime;
    private readonly InputAction m_Base_SubstractTime;
    private readonly InputAction m_Base_Interact;
    public struct BaseActions
    {
        private @MyInputActions m_Wrapper;
        public BaseActions(@MyInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_Base_Pause;
        public InputAction @Horizontal => m_Wrapper.m_Base_Horizontal;
        public InputAction @Jump => m_Wrapper.m_Base_Jump;
        public InputAction @Switch => m_Wrapper.m_Base_Switch;
        public InputAction @AddTime => m_Wrapper.m_Base_AddTime;
        public InputAction @SubstractTime => m_Wrapper.m_Base_SubstractTime;
        public InputAction @Interact => m_Wrapper.m_Base_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Base; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BaseActions set) { return set.Get(); }
        public void SetCallbacks(IBaseActions instance)
        {
            if (m_Wrapper.m_BaseActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnPause;
                @Horizontal.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnHorizontal;
                @Horizontal.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnHorizontal;
                @Horizontal.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnHorizontal;
                @Jump.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnJump;
                @Switch.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnSwitch;
                @Switch.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnSwitch;
                @Switch.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnSwitch;
                @AddTime.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnAddTime;
                @AddTime.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnAddTime;
                @AddTime.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnAddTime;
                @SubstractTime.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnSubstractTime;
                @SubstractTime.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnSubstractTime;
                @SubstractTime.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnSubstractTime;
                @Interact.started -= m_Wrapper.m_BaseActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_BaseActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_BaseActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_BaseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Horizontal.started += instance.OnHorizontal;
                @Horizontal.performed += instance.OnHorizontal;
                @Horizontal.canceled += instance.OnHorizontal;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Switch.started += instance.OnSwitch;
                @Switch.performed += instance.OnSwitch;
                @Switch.canceled += instance.OnSwitch;
                @AddTime.started += instance.OnAddTime;
                @AddTime.performed += instance.OnAddTime;
                @AddTime.canceled += instance.OnAddTime;
                @SubstractTime.started += instance.OnSubstractTime;
                @SubstractTime.performed += instance.OnSubstractTime;
                @SubstractTime.canceled += instance.OnSubstractTime;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public BaseActions @Base => new BaseActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface IBaseActions
    {
        void OnPause(InputAction.CallbackContext context);
        void OnHorizontal(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnSwitch(InputAction.CallbackContext context);
        void OnAddTime(InputAction.CallbackContext context);
        void OnSubstractTime(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
}
