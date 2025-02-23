using Codebase.MessangerService;
using Codebase.SaveLoad;
using Codebase.UI.Screens.Hud;
using UnityEngine;
using VContainer;

namespace Codebase.UI.Screens.Pause
{
    public class PauseScreen : BaseViw
    {
        [SerializeField] private Timer _timer;
        private IMessengerService _messengerService;
        private ISaveLoadService _saveLoadService;
        public override ViewType ViewType => ViewType.Pause;

        [Inject]
        public void Inject(IMessengerService messengerService, ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
            _messengerService = messengerService;
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
            {
                Hide();
            }
        }

        public override void Show(object payload = null)
        {
            _timer.StopTimer();
            _messengerService.Send(this, new PauseMessage(true));
            base.Show(payload);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }

        public override void Hide()
        {
            Time.timeScale = 1;
            _timer.Resume();
            _messengerService.Send(this, new PauseMessage(false));
            base.Hide();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void OnResume()
        {
            Hide();
        }

        public void OnSave()
        {
            _saveLoadService.SaveGameData();;
        }

        public void OnQuit()
        {
            Application.Quit();
        }
    }
}