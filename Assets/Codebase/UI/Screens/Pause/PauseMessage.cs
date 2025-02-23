using Codebase.MessangerService;

namespace Codebase.UI.Screens.Pause
{
    public class PauseMessage : IMessage
    {
        public bool IsPaused { get; }

        public PauseMessage(bool isPaused)
        {
            IsPaused = isPaused;
        }
    }
}