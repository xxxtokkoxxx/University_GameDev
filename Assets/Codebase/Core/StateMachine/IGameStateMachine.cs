namespace Codebase.Core.StateMachine
{
    public interface IGameStateMachine
    {
        void Initialize();
        void ChangeState<TState>(object payload = null) where TState : IState;
    }
}