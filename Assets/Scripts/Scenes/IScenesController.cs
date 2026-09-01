using Cysharp.Threading.Tasks;

namespace PlatformerTest.Scenes
{
    public interface IScenesController
    {
        UniTaskVoid LoadScene(int id);
    }
}