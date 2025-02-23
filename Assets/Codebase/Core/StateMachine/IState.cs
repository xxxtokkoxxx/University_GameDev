namespace Codebase.Core.StateMachine
{
    public interface IState
    {
        void Enter(object payload = null);
        void Exit();
    }
}