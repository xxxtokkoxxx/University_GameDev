namespace Codebase.Core.StateMachine
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}