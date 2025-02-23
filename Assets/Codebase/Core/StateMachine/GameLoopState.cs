using Codebase.Core.SceneManagement;
using Codebase.Environment;
using Codebase.SaveLoad;
using Codebase.UI;
using UnityEngine;

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

        public async void Enter(object payload = null)
        {
            await _sceneLoader.LoadScene(SceneLoader.GameLoopScene);
            LevelEnvironment levelEnvironment = Object.FindFirstObjectByType<LevelEnvironment>();
            levelEnvironment.LoadMovableItems();

            _uiService.ShowScreen(ViewType.HUD);

            if (payload is GameData gameData)
            {
                Player.Player player = Object.FindFirstObjectByType<Player.Player>();
                player.transform.position = new Vector3(gameData.PlayerData.Position.X, gameData.PlayerData.Position.Y, gameData.PlayerData.Position.Z);
                player.transform.rotation = Quaternion.Euler(gameData.PlayerData.Position.X, gameData.PlayerData.Position.Y, gameData.PlayerData.Position.Z);
                levelEnvironment.SetLevelData(gameData.LevelData);
            }
            else
            {
                levelEnvironment.LoadDefaultLevel();
            }
        }

        public void Exit() { }
    }
}