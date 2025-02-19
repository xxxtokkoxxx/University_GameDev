using Codebase.MessangerService;
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

        private IMessengerService _messengerService;
        private bool _registered;

        public override ViewType ViewType => ViewType.HUD;

        [Inject]
        public void Inject(IMessengerService messengerService)
        {
            _messengerService = messengerService;
        }

        public void Receive(object sender, object message)
        {
            if (message is TimerEndMessage)
            {
                _gameOverText.gameObject.SetActive(true);
                _timer.StopTimer();
                _gameOverText.text = "Game Over\n" +
                                     $"Your scores: {_scoreCounter.GetScores()}";
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
            _timer.StopTimer();
        }
    }
}