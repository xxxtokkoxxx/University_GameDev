using System;
using System.Collections;
using Codebase.GameLoop;
using TMPro;
using UnityEngine;

namespace Codebase.UI.HUD
{
    public class Timer : MonoBehaviour
    {
        public event Action OnTimerEnd;

        [SerializeField] private GameManager _gameManager;
        [SerializeField] private float _gameDuration = 30;
        [SerializeField] private TextMeshProUGUI _timerText;

        private void Start()
        {
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

            OnTimerEnd?.Invoke();
        }

        public void StopTimer()
        {
            StopAllCoroutines();
            _timerText.text = "Timer: 00.00";
        }
    }
}