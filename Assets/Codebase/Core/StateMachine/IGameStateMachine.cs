namespace Codebase.Core.StateMachine
{
    public interface IGameStateMachine
    {
        void Initialize();
        void ChangeState<TState>() where TState : IState;
    }
}