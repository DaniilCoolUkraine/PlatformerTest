using System;
using System.Collections.Generic;
using SimpleEventBus.SimpleEventBus.Runtime;
using UnityEngine.InputSystem;

namespace PlatformerTest.Impl.Processors
{
    public sealed class DebugInputProcessor : EventDispatchingInputProcessor
    {
        private const string LoadMainSceneActionName = "LoadMainScene";
        private const string LoadGameplaySceneActionName = "LoadGameplayScene";

        public DebugInputProcessor(InputActionMap map) : base(map)
        {
        }

        protected override Dictionary<InputAction, Action> BuildEventMap(InputActionMap map)
        {
            var loadMainSceneAction = map.FindAction(LoadMainSceneActionName)
                                      ?? throw new ArgumentNullException("loadMainSceneAction", $"Action '{LoadMainSceneActionName}' not found in map '{map.name}'.");
            var loadGameplaySceneAction = map.FindAction(LoadGameplaySceneActionName)
                                          ?? throw new ArgumentNullException("loadGameplaySceneAction", $"Action '{LoadGameplaySceneActionName}' not found in map '{map.name}'.");

            return new Dictionary<InputAction, Action>
            {
                { loadMainSceneAction, () => GlobalEvents.Publish(new LoadMainSceneEvent()) },
                { loadGameplaySceneAction, () => GlobalEvents.Publish(new LoadGameplaySceneEvent()) },
            };
        }
    }
}