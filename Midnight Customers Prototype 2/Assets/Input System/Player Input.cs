// GENERATED AUTOMATICALLY FROM 'Assets/Input System/Player Input.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Input"",
    ""maps"": [
        {
            ""name"": ""Store"",
            ""id"": ""203bd9ed-8357-4956-baae-58af411dff8c"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""f700c7f4-c842-4f06-81e5-f164119dae00"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""5c8ab8fe-66c1-4112-a637-783d3a1e2e27"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""a56b438e-eff0-458f-ae4d-765e783da2fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""5007587f-e891-4bf4-97ac-e85d4f2fd2d5"",
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
                    ""id"": ""26c71945-d78e-4bde-83ff-0450a9242c93"",
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
                    ""id"": ""bc1166d0-c0da-4a8b-94cd-d8c3eb0888ec"",
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
                    ""id"": ""6450cebb-ea3a-4849-a0f7-e860595ab2d1"",
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
                    ""id"": ""051afc36-11ac-4851-ad53-5a818990fc85"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""3e4b3f45-59fb-456b-84f5-ac5e0e95a49b"",
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
                    ""id"": ""c6abba21-d486-478f-8629-7850a61ebc8c"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2826a857-b3cc-421e-b14a-d7b1d2e5f5ed"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""39004140-e719-4514-8089-250db3196378"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8dfc4d6a-8271-4612-a09e-91725a336480"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""97ae378a-b473-43a7-8bc7-56ced21be7c1"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8629cd1f-6049-416f-af74-0caf6c7b2f73"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1a17d67c-fe13-400d-9c8d-3a087707c58c"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Checkout"",
            ""id"": ""2c850802-727d-43ba-aadb-818a9c3d6bb4"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""fe55b30e-1ed1-4261-a27a-292be2da8121"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4d9f605a-fe2e-41d6-af4d-213aed5fd680"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Minigame"",
            ""id"": ""4802116e-77ba-4358-97a1-d985a7eb0664"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""0498dc50-c6f0-4ee8-b40a-30519023186a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fddeef82-8f67-4a3e-aea2-7bbf345f0595"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""a5aa86e4-5099-4bd2-be49-945050c7347e"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""c9ca83c8-b872-47de-b7f8-b2234f3ee75e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""92e1679e-8a0b-42d0-8f3d-61bb06469c80"",
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
        // Store
        m_Store = asset.FindActionMap("Store", throwIfNotFound: true);
        m_Store_Move = m_Store.FindAction("Move", throwIfNotFound: true);
        m_Store_Interact = m_Store.FindAction("Interact", throwIfNotFound: true);
        m_Store_Pause = m_Store.FindAction("Pause", throwIfNotFound: true);
        // Checkout
        m_Checkout = asset.FindActionMap("Checkout", throwIfNotFound: true);
        m_Checkout_Newaction = m_Checkout.FindAction("New action", throwIfNotFound: true);
        // Minigame
        m_Minigame = asset.FindActionMap("Minigame", throwIfNotFound: true);
        m_Minigame_Newaction = m_Minigame.FindAction("New action", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Newaction = m_Menu.FindAction("New action", throwIfNotFound: true);
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

    // Store
    private readonly InputActionMap m_Store;
    private IStoreActions m_StoreActionsCallbackInterface;
    private readonly InputAction m_Store_Move;
    private readonly InputAction m_Store_Interact;
    private readonly InputAction m_Store_Pause;
    public struct StoreActions
    {
        private @PlayerInput m_Wrapper;
        public StoreActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Store_Move;
        public InputAction @Interact => m_Wrapper.m_Store_Interact;
        public InputAction @Pause => m_Wrapper.m_Store_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Store; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(StoreActions set) { return set.Get(); }
        public void SetCallbacks(IStoreActions instance)
        {
            if (m_Wrapper.m_StoreActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_StoreActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_StoreActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_StoreActionsCallbackInterface.OnMove;
                @Interact.started -= m_Wrapper.m_StoreActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_StoreActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_StoreActionsCallbackInterface.OnInteract;
                @Pause.started -= m_Wrapper.m_StoreActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_StoreActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_StoreActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_StoreActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public StoreActions @Store => new StoreActions(this);

    // Checkout
    private readonly InputActionMap m_Checkout;
    private ICheckoutActions m_CheckoutActionsCallbackInterface;
    private readonly InputAction m_Checkout_Newaction;
    public struct CheckoutActions
    {
        private @PlayerInput m_Wrapper;
        public CheckoutActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Checkout_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Checkout; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CheckoutActions set) { return set.Get(); }
        public void SetCallbacks(ICheckoutActions instance)
        {
            if (m_Wrapper.m_CheckoutActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_CheckoutActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_CheckoutActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_CheckoutActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_CheckoutActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public CheckoutActions @Checkout => new CheckoutActions(this);

    // Minigame
    private readonly InputActionMap m_Minigame;
    private IMinigameActions m_MinigameActionsCallbackInterface;
    private readonly InputAction m_Minigame_Newaction;
    public struct MinigameActions
    {
        private @PlayerInput m_Wrapper;
        public MinigameActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Minigame_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Minigame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MinigameActions set) { return set.Get(); }
        public void SetCallbacks(IMinigameActions instance)
        {
            if (m_Wrapper.m_MinigameActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_MinigameActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_MinigameActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_MinigameActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_MinigameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public MinigameActions @Minigame => new MinigameActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_Newaction;
    public struct MenuActions
    {
        private @PlayerInput m_Wrapper;
        public MenuActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Menu_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    public interface IStoreActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface ICheckoutActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
    public interface IMinigameActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
