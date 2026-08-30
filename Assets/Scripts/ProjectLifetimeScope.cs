using PlatformerTest.Impl;
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
            builder.Register<IInputController, InputController>(Lifetime.Singleton);
            
            builder.RegisterBuildCallback(resolver =>
            {
                resolver.Resolve<IInputController>();
            });
        }
    }
}