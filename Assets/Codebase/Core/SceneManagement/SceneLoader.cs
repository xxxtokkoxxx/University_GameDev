using UnityEngine.SceneManagement;

namespace Codebase.Core.SceneManagement
{
    public class SceneLoader : ISceneLoader
    {
        public const string InitialScene = "InitialScene";
        public const string MainMenuScene = "MainMenuScene";
        public const string GameLoopScene = "GameLoopScene";

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}