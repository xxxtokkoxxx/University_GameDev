using Codebase.Core.SceneManagement;
using UnityEngine.SceneManagement;

namespace Codebase.Core.StateMachine
{
    public class InitialState : IState
    {
        private readonly ISceneLoader _sceneLoader;

        public InitialState(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Enter(object payload = null)
        {
            if (SceneManager.GetActiveScene().name != SceneLoader.InitialScene)
            {
                _sceneLoader.LoadScene(SceneLoader.InitialScene);
            }
        }

        public void Exit() { }
    }
}