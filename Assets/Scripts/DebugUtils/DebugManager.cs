using PlatformerTest.InputController;
using PlatformerTest.Scenes;
using SimpleEventBus.SimpleEventBus.Runtime;
using UnityEngine;
using VContainer;

namespace PlatformerTest.DebugUtils
{
    public class DebugManager : MonoBehaviour
    {
        [Inject] private IScenesController _scenesController;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

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
            _scenesController.LoadScene(Scenes.Scenes.MainMenu);
        }

        private void OnGameplaySceneLoad(LoadGameplaySceneEvent ev)
        {
            _scenesController.LoadScene(Scenes.Scenes.GameplayScene);
        }
    }
}