using System.Collections;
using Codebase.MessangerService;
using TMPro;
using UnityEngine;

namespace Codebase.UI.Screens.Hud
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float _gameDuration = 30;
        [SerializeField] private TextMeshProUGUI _timerText;

        private IMessengerService _messengerService;

        public void Initialize(IMessengerService messengerService)
        {
            _messengerService = messengerService;
        }

        public void StartTimer()
        {
            ResetTimer();
            StartCoroutine(RunTimer());
        }

        private IEnumerator RunTimer()
        {
            while (_gameDuration > 0)
            {
                _gameDuration -= Time.deltaTime;
                _timerText.text = $"Timer: {_gameDuration:00.00}";
                yield return null;
            }

            _messengerService.Send(this, new TimerEndMessage());
        }

        public void ResetTimer()
        {
            StopAllCoroutines();
            _timerText.text = "Timer: 00.00";
        }

        public void StopTimer()
        {
            StopAllCoroutines();
        }

        public void Resume()
        {
            StartCoroutine(RunTimer());
        }
    }
}