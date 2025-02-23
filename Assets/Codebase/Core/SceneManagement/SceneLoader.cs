using UnityEngine;
using UnityEngine.SceneManagement;
using Task = System.Threading.Tasks.Task;

namespace Codebase.Core.SceneManagement
{
    public class SceneLoader : ISceneLoader
    {
        public const string InitialScene = "InitialScene";
        public const string MainMenuScene = "MainMenu";
        public const string GameLoopScene = "GameLoop";

        public async Task LoadScene(string sceneName)
        {
            await SceneManager.LoadSceneAsync(sceneName)!;
        }
    }
}