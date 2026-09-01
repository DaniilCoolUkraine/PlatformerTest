using PlatformerTest.InputController;
using PlatformerTest.Scenes;
using PlatformerTest.Scenes.Impl;
using VContainer;
using VContainer.Unity;

namespace PlatformerTest
{
    public class ProjectLifetimeScope : LifetimeScope
    {
        protected override void Awake()
        {
            DontDestroyOnLoad(gameObject);
            base.Awake();
        }

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IInputController, InputController.Impl.InputController>(Lifetime.Singleton);
            builder.Register<IScenesController, ScenesControllerLazy>(Lifetime.Singleton);

            builder.RegisterBuildCallback(resolver =>
            {
                resolver.Resolve<IInputController>();
            });
        }
    }
}