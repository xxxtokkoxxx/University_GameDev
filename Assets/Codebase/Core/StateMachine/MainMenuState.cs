using Codebase.Core.SceneManagement;
using Codebase.UI;

namespace Codebase.Core.StateMachine
{
    public class MainMenuState : IState
    {
        private readonly IUiService _uiService;
        private readonly ISceneLoader _sceneLoader;

        public MainMenuState(IUiService uiService, ISceneLoader sceneLoader)
        {
            _uiService = uiService;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.LoadScene(SceneLoader.MainMenuScene);
            _uiService.ShowScreen(ViewType.MainMenu);
        }

        public void Exit()
        {
            _uiService.HideScreen(ViewType.MainMenu);
        }
    }
}