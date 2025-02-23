using Codebase.Environment;
using Codebase.MessangerService;
using Codebase.UI.Screens.Pause;
using TMPro;
using UnityEngine;
using VContainer;

namespace Codebase.UI.Screens.Hud
{
    public class HudView : BaseViw, IListener
    {
        [SerializeField] private Timer _timer;
        [SerializeField] private ScoreCounter _scoreCounter;
        [SerializeField] private TextMeshProUGUI _gameOverText;
        [SerializeField] private AudioSource _pickCoinAudio;

        private IMessengerService _messengerService;
        private bool _registered;
        private IUiService _uiService;
        private bool _isPaused;

        public override ViewType ViewType => ViewType.HUD;

        [Inject]
        public void Inject(IMessengerService messengerService, IUiService uiService)
        {
            _uiService = uiService;
            _messengerService = messengerService;
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
            {
                if (_isPaused)
                    return;

                _uiService.ShowScreen(ViewType.Pause);
            }
        }

        public void Receive(object sender, object message)
        {
            if (message is TimerEndMessage)
            {
                ShowGameOverWindow();
            }

            if (message is PickCoinMessage)
            {
                _scoreCounter.AddScore(1);
                _pickCoinAudio.Play();
            }

            if (message is PauseMessage pauseMessage)
            {
                _isPaused = pauseMessage.IsPaused;
            }
        }

        public override void Show(object payload = null)
        {
            base.Show(payload);

            _gameOverText.gameObject.SetActive(false);
            if (!_registered)
            {
                _timer.Initialize(_messengerService);
                _messengerService.Register(this);
                _registered = true;
            }

            _timer.StartTimer();
            _scoreCounter.Reset();
        }

        public override void Hide()
        {
            _timer.ResetTimer();
        }

        private void ShowGameOverWindow()
        {
            ShowPauseWindow();

            if (Application.isEditor)
            {
                Application.Quit();
            }
            else
            {
                _gameOverText.gameObject.SetActive(true);
                _timer.ResetTimer();
                _gameOverText.text = "Game Over\n" +
                                     $"Your scores: {_scoreCounter.GetScores()}";
            }
        }

        private void ShowPauseWindow()
        {
            _uiService.ShowScreen(ViewType.Pause);
        }
    }
}