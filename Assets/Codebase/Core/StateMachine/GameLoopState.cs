using Codebase.Core.SceneManagement;
using Codebase.UI;

namespace Codebase.Core.StateMachine
{
    public class GameLoopState : IState
    {
        private readonly IUiService _uiService;
        private readonly ISceneLoader _sceneLoader;

        public GameLoopState(IUiService uiService, ISceneLoader sceneLoader)
        {
            _uiService = uiService;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.LoadScene(SceneLoader.GameLoopScene);
            _uiService.ShowScreen(ViewType.HUD);
        }

        public void Exit() { }
    }
}