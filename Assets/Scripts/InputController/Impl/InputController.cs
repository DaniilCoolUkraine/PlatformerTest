using System;
using PlatformerTest.InputController.Impl.Processors;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlatformerTest.InputController.Impl
{
    public sealed class InputController : IInputController
    {
        private const string PathToAsset = "InputSystem_Actions";

        private const string PathToPlayerMap = "Player";
        private const string PathToUIMap = "UI";
        private const string PathToDebugMap = "Debug";

        private readonly InputActionAsset _inputActionAsset;

        private readonly PlayerInputProcessor _playerProcessor;

        public InputController()
        {
            UnityEngine.Debug.Log("InputController construct");
            
            _inputActionAsset = Resources.Load<InputActionAsset>(PathToAsset);
            if (_inputActionAsset == null)
            {
                throw new ArgumentNullException(nameof(_inputActionAsset), "Input asset couldn't be found!");
            }

            _playerProcessor = new PlayerInputProcessor(FindMap(PathToPlayerMap));
            var uiProcessor = new UIInputProcessor(FindMap(PathToUIMap));
            var debugProcessor = new DebugInputProcessor(FindMap(PathToDebugMap));

            _playerProcessor.Enable();
            uiProcessor.Disable();

#if UNITY_EDITOR || DEV_BUILD
            debugProcessor.Enable();
#else
            debugProcessor.Disable();
#endif
        }

        public Vector2 GetMovementInput() => _playerProcessor.GetMovementInput();

        public bool GetSprintInput() => _playerProcessor.GetSprintInput();

        public bool GetJumpInput() => _playerProcessor.GetJumpInput();

        private InputActionMap FindMap(string mapName)
        {
            var map = _inputActionAsset.FindActionMap(mapName);
            if (map == null)
            {
                throw new ArgumentNullException(nameof(map),
                    $"Action map '{mapName}' not found in asset '{PathToAsset}'.");
            }

            return map;
        }
    }
}