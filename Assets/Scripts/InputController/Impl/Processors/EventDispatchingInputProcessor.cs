using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace PlatformerTest.InputController.Impl.Processors
{
    public abstract class EventDispatchingInputProcessor : IInputProcessor
    {
        private readonly InputActionMap _map;
        private readonly Dictionary<InputAction, Action> _eventMap;

        protected EventDispatchingInputProcessor(InputActionMap map)
        {
            _map = map ?? throw new ArgumentNullException(nameof(map));
            _eventMap = BuildEventMap(map);
        }

        /// <summary>
        /// Build the InputAction -> publish-delegate table once, at construction.
        /// Resolve actions via map.FindAction and throw if one is missing, so a
        /// renamed/removed action fails loudly at startup instead of silently
        /// never firing.
        /// </summary>
        protected abstract Dictionary<InputAction, Action> BuildEventMap(InputActionMap map);

        public void Enable()
        {
            _map.Enable();
            _map.actionTriggered += OnActionTriggered;
        }

        public void Disable()
        {
            _map.actionTriggered -= OnActionTriggered;
            _map.Disable();
        }

        private void OnActionTriggered(InputAction.CallbackContext context)
        {
            // actionTriggered fires on every phase (started/performed/canceled).
            // Only dispatch on Performed, otherwise one button press publishes 2-3 times.
            if (context.phase != InputActionPhase.Performed)
            {
                return;
            }

            if (_eventMap.TryGetValue(context.action, out var publish))
            {
                publish();
            }
        }
    }
}