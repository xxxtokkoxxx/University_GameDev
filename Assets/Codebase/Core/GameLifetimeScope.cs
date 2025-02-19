using Codebase.Core.SceneManagement;
using Codebase.Core.StateMachine;
using Codebase.MessangerService;
using Codebase.UI;
using VContainer;
using VContainer.Unity;

namespace Codebase.Core
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IGameStateMachine, GameStateMachine>(Lifetime.Singleton);
            builder.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
            builder.Register<IUiService, UiService>(Lifetime.Singleton);
            builder.Register<IMessengerService, MessengerService>(Lifetime.Singleton);
        }
    }
}