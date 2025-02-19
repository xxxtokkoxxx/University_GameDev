namespace Codebase.MessangerService
{
    public interface IMessengerService
    {
        void Send(object sender, IMessage message);
        void Register(IListener listener);
        void Unregister(IListener listener);
    }
}