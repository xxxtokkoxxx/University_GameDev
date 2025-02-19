using UnityEngine.SceneManagement;

namespace Codebase.Core.SceneManagement
{
    public class SceneLoader : ISceneLoader
    {
        public const string InitialScene = "InitialScene";
        public const string MainMenuScene = "MainMenu";
        public const string GameLoopScene = "GameLoop";

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}