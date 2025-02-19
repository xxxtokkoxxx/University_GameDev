using Codebase.Core.StateMachine;
using UnityEngine;
using VContainer;
using Application = UnityEngine.Application;

namespace Codebase.UI.Screens.MainMenu
{
    public class MainMenuView : BaseViw
    {
        private IGameStateMachine _stateMachine;
        private IUiService _uiService;

        public override ViewType ViewType => ViewType.MainMenu;

        [Inject]
        public void Inject(IGameStateMachine stateMachine, IUiService uiService)
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
            Debug.Log("ui service " + _uiService);
            _uiService.HideScreen(ViewType);
            _uiService.ShowScreen(ViewType.Settings);
        }

        public void OnExitPressed()
        {
            Application.Quit();
        }
    }
}