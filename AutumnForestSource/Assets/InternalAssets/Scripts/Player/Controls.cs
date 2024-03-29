//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/InternalAssets/Controls.inputactions
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

namespace AutumnForest
{
    public partial class @PlayerInput : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Inputs"",
            ""id"": ""f0a43ca5-13d6-4421-ac5d-de09678c52eb"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""7aed9060-788d-473e-816c-1f50523f055b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""3b6dfd48-9486-4bbb-8ad1-82fb5ce24563"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""2063b4ea-981f-43d3-b904-cbf56e474112"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""884a8411-46da-472f-9031-613233545b5c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dialogue"",
                    ""type"": ""Button"",
                    ""id"": ""89e7b15f-d6f0-4164-af14-ce582f173a9c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Slingshot"",
                    ""type"": ""Button"",
                    ""id"": ""89e039ef-761f-4324-ac72-3ea00fbaa04d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PauseMenu"",
                    ""type"": ""Button"",
                    ""id"": ""fd880cd6-1a73-4ea6-93ed-afb9ef714581"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b19c5177-3a6a-408b-8bfc-b247348dc21a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d33b374f-07d5-4ae9-b0e6-2868393fe923"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""681a28db-1739-421b-bda5-03a4d6483030"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""d0389bb0-70d3-43b5-a0f7-7fa96235e5d5"",
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
                    ""id"": ""c9764ccd-b439-4e96-b49d-edbd51b6d263"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5ccb08f8-b455-4121-a88e-9ed6b1af02ee"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e087b493-7240-41e9-9727-87dda74584f8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""bc5b983a-dc75-4219-9d39-511626c9dba6"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c67ef55a-b634-46b3-b9bd-71615e8f9e6a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dialogue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5cb21134-409b-4d95-bf01-f48d83ac64b4"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slingshot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d96dfa63-eb23-497d-96c7-e0e111e69277"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardMouse"",
            ""bindingGroup"": ""KeyboardMouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Inputs
            m_Inputs = asset.FindActionMap("Inputs", throwIfNotFound: true);
            m_Inputs_Move = m_Inputs.FindAction("Move", throwIfNotFound: true);
            m_Inputs_Attack = m_Inputs.FindAction("Attack", throwIfNotFound: true);
            m_Inputs_Interact = m_Inputs.FindAction("Interact", throwIfNotFound: true);
            m_Inputs_Dash = m_Inputs.FindAction("Dash", throwIfNotFound: true);
            m_Inputs_Dialogue = m_Inputs.FindAction("Dialogue", throwIfNotFound: true);
            m_Inputs_Slingshot = m_Inputs.FindAction("Slingshot", throwIfNotFound: true);
            m_Inputs_PauseMenu = m_Inputs.FindAction("PauseMenu", throwIfNotFound: true);
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

        // Inputs
        private readonly InputActionMap m_Inputs;
        private IInputsActions m_InputsActionsCallbackInterface;
        private readonly InputAction m_Inputs_Move;
        private readonly InputAction m_Inputs_Attack;
        private readonly InputAction m_Inputs_Interact;
        private readonly InputAction m_Inputs_Dash;
        private readonly InputAction m_Inputs_Dialogue;
        private readonly InputAction m_Inputs_Slingshot;
        private readonly InputAction m_Inputs_PauseMenu;
        public struct InputsActions
        {
            private @PlayerInput m_Wrapper;
            public InputsActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Inputs_Move;
            public InputAction @Attack => m_Wrapper.m_Inputs_Attack;
            public InputAction @Interact => m_Wrapper.m_Inputs_Interact;
            public InputAction @Dash => m_Wrapper.m_Inputs_Dash;
            public InputAction @Dialogue => m_Wrapper.m_Inputs_Dialogue;
            public InputAction @Slingshot => m_Wrapper.m_Inputs_Slingshot;
            public InputAction @PauseMenu => m_Wrapper.m_Inputs_PauseMenu;
            public InputActionMap Get() { return m_Wrapper.m_Inputs; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(InputsActions set) { return set.Get(); }
            public void SetCallbacks(IInputsActions instance)
            {
                if (m_Wrapper.m_InputsActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnMove;
                    @Attack.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnAttack;
                    @Attack.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnAttack;
                    @Attack.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnAttack;
                    @Interact.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnInteract;
                    @Interact.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnInteract;
                    @Interact.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnInteract;
                    @Dash.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnDash;
                    @Dash.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnDash;
                    @Dash.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnDash;
                    @Dialogue.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnDialogue;
                    @Dialogue.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnDialogue;
                    @Dialogue.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnDialogue;
                    @Slingshot.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnSlingshot;
                    @Slingshot.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnSlingshot;
                    @Slingshot.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnSlingshot;
                    @PauseMenu.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnPauseMenu;
                    @PauseMenu.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnPauseMenu;
                    @PauseMenu.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnPauseMenu;
                }
                m_Wrapper.m_InputsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Attack.started += instance.OnAttack;
                    @Attack.performed += instance.OnAttack;
                    @Attack.canceled += instance.OnAttack;
                    @Interact.started += instance.OnInteract;
                    @Interact.performed += instance.OnInteract;
                    @Interact.canceled += instance.OnInteract;
                    @Dash.started += instance.OnDash;
                    @Dash.performed += instance.OnDash;
                    @Dash.canceled += instance.OnDash;
                    @Dialogue.started += instance.OnDialogue;
                    @Dialogue.performed += instance.OnDialogue;
                    @Dialogue.canceled += instance.OnDialogue;
                    @Slingshot.started += instance.OnSlingshot;
                    @Slingshot.performed += instance.OnSlingshot;
                    @Slingshot.canceled += instance.OnSlingshot;
                    @PauseMenu.started += instance.OnPauseMenu;
                    @PauseMenu.performed += instance.OnPauseMenu;
                    @PauseMenu.canceled += instance.OnPauseMenu;
                }
            }
        }
        public InputsActions @Inputs => new InputsActions(this);
        private int m_KeyboardMouseSchemeIndex = -1;
        public InputControlScheme KeyboardMouseScheme
        {
            get
            {
                if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardMouse");
                return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
            }
        }
        public interface IInputsActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnAttack(InputAction.CallbackContext context);
            void OnInteract(InputAction.CallbackContext context);
            void OnDash(InputAction.CallbackContext context);
            void OnDialogue(InputAction.CallbackContext context);
            void OnSlingshot(InputAction.CallbackContext context);
            void OnPauseMenu(InputAction.CallbackContext context);
        }
    }
}
