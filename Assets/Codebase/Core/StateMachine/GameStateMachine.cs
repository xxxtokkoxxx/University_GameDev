using System.Collections.Generic;
using Codebase.Core.SceneManagement;
using Codebase.UI;
using Unity.VisualScripting;

namespace Codebase.Core.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly IUiService _uiService;
        private readonly ISceneLoader _sceneLoader;
        private IState _previousState;

        private List<IState> _states = new();

        public GameStateMachine(IUiService uiService, ISceneLoader sceneLoader)
        {
            _uiService = uiService;
            _sceneLoader = sceneLoader;
        }

        public void Initialize()
        {
            _states = new()
            {
                new InitialState(_sceneLoader),
                new GameLoopState(_uiService, _sceneLoader),
                new MainMenuState(_uiService, _sceneLoader)
            };
        }

        public void ChangeState<TState>() where TState : IState
        {
            IState state = _states.Find(state => state.GetType() == typeof(TState));

            if (_previousState != null)
            {
                _previousState.Exit();
            }

            _previousState = state;
            state.Enter();
        }
    }
}