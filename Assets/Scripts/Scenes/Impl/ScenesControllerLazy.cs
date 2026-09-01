using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace PlatformerTest.Scenes.Impl
{
    public class ScenesControllerLazy : IScenesController
    {
        private bool _isLoading;
        
        public async UniTaskVoid LoadScene(int id)
        {
            if (_isLoading)
                return;

            _isLoading = true;
            await SceneManager.LoadSceneAsync(id).ToUniTask();

            _isLoading = false;
        }
    }
}