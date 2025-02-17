using Codebase.Core.StateMachine;
using VContainer;
using Application = UnityEngine.Application;

namespace Codebase.UI.Screens.MainMenu
{
    public class MainMenuView : BaseViw
    {
        private readonly IGameStateMachine _stateMachine;
        private IUiService _uiService;

        public override ViewType ViewType => ViewType.MainMenu;

        [Inject]
        public MainMenuView(IGameStateMachine stateMachine, IUiService uiService)
        {
            _uiService = uiService;
            _stateMachine = stateMachine;
        }

        public void OnStartGamePressed()
        {
            _stateMachine.ChangeState<GameLoopState>();
        }

        public void OnSettingsPressed()
        {
            _uiService.ShowScreen(ViewType.Settings);
        }

        public void OnExitPressed()
        {
            Application.Quit();
        }
    }
}