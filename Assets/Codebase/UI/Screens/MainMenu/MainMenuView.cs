using System.IO;
using Codebase.Core.StateMachine;
using Codebase.SaveLoad;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using Application = UnityEngine.Application;

namespace Codebase.UI.Screens.MainMenu
{
    public class MainMenuView : BaseViw
    {
        [SerializeField] private GameObject _loadGameButton;
        [SerializeField] private RectTransform _layoutGroup;

        private IGameStateMachine _stateMachine;
        private IUiService _uiService;
        private ISaveLoadService _saveLoadService;

        public override ViewType ViewType => ViewType.MainMenu;

        [Inject]
        public void Inject(IGameStateMachine stateMachine,
            IUiService uiService,
            ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
            _uiService = uiService;
            _stateMachine = stateMachine;
        }

        public override void Show(object payload = null)
        {
            base.Show(payload);

            string filePath = Path.Combine(Application.persistentDataPath, SaveLoadService.SaveFileName);
            bool isActive = File.Exists(filePath);
            _loadGameButton.SetActive(isActive);
            LayoutRebuilder.ForceRebuildLayoutImmediate(_layoutGroup);
        }

        public void OnStartGamePressed()
        {
            _stateMachine.ChangeState<GameLoopState>();
        }

        public void OnLoadGamePressed()
        {
            string filePath = Path.Combine(Application.persistentDataPath, SaveLoadService.SaveFileName);
            bool saveExists = File.Exists(filePath);

            if (!saveExists)
                return;

            GameData gameData = _saveLoadService.LoadGameData();
            _stateMachine.ChangeState<GameLoopState>(gameData);
        }

        public void OnSettingsPressed()
        {
            _uiService.HideScreen(ViewType);
            _uiService.ShowScreen(ViewType.Settings);
        }

        public void OnExitPressed()
        {
            Application.Quit();
        }
    }
}