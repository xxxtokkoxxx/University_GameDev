using System.Collections.Generic;

namespace Codebase.MessangerService
{
    public class MessengerService : IMessengerService
    {
        private List<IListener> _listeners = new();

        public void Send(object sender, IMessage message)
        {
            foreach (IListener listener in _listeners)
            {
                listener.Receive(sender, message);
            }
        }

        public void Register(IListener listener)
        {
            _listeners.Add(listener);
        }

        public void Unregister(IListener listener)
        {
            _listeners.Remove(listener);
        }
    }
}