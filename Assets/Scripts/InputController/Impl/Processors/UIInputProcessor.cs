using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace PlatformerTest.Impl.Processors
{
    public class UIInputProcessor : EventDispatchingInputProcessor
    {
        public UIInputProcessor(InputActionMap map) : base(map)
        {
        }

        protected override Dictionary<InputAction, Action> BuildEventMap(InputActionMap map)
        {
            return new Dictionary<InputAction, Action>
            {
                // { map.FindAction("SomeUIAction"), () => GlobalEvents.Publish(new SomeUIEvent()) },
            };
        }
    }
}