using System.Collections.Generic;
using Unity.VisualScripting;

namespace Codebase.Core.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private IState _previousState;

        private List<IState> _states = new()
        {
            new InitialState(),
            new ExitGameState(),
            new GameLoopState(),
            new GameOverState(),
            new MainMenuState()
        };

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