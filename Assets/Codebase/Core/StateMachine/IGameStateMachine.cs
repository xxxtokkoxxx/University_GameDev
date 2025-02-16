namespace Codebase.Core.StateMachine
{
    public interface IGameStateMachine
    {
        void ChangeState<TState>() where TState : IState;
    }
}