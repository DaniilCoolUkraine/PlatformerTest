using SimpleEventBus.SimpleEventBus.Runtime;
using UnityEngine;
using VContainer;

namespace PlatformerTest.Debug
{
    public class DebugManager : MonoBehaviour
    {
        [Inject] private IInputController _inputController;

        private void OnEnable()
        {
            GlobalEvents.AddListener<LoadMainSceneEvent>(OnMainSceneLoad);
            GlobalEvents.AddListener<LoadGameplaySceneEvent>(OnGameplaySceneLoad);
        }

        private void OnDisable()
        {
            GlobalEvents.RemoveListener<LoadMainSceneEvent>(OnMainSceneLoad);
            GlobalEvents.RemoveListener<LoadGameplaySceneEvent>(OnGameplaySceneLoad);
        }

        private void OnMainSceneLoad(LoadMainSceneEvent ev)
        {
            UnityEngine.Debug.Log("OnMainSceneLoad");
        }

        private void OnGameplaySceneLoad(LoadGameplaySceneEvent ev)
        {
            UnityEngine.Debug.Log("OnGameplaySceneLoad");
        }
    }
}