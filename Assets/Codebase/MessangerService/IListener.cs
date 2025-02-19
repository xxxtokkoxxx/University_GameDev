namespace Codebase.MessangerService
{
    public interface IListener
    {
        void Receive(object sender, object message);
    }
}