using Codebase.Input;
using Codebase.UI.Screens.Hud;
using TMPro;
using UnityEngine;

namespace Codebase.GameLoop
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Timer _timer;
        [SerializeField] private ScoreCounter _scoreCounter;
        [SerializeField] private TextMeshProUGUI _gameOverText;
        [SerializeField] private MouseLook _mouseLook;
        [SerializeField] private FPSInput _fpsInput;

        private void Start()
        {
            _timer.OnTimerEnd += EndGame;
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
            {
                EndGame();
            }
        }

        private void EndGame()
        {
            Application.Quit();
            _timer.StopTimer();
            _gameOverText.gameObject.SetActive(true);
            _gameOverText.text = "Game Over\n" +
                                 $"Your scores: {_scoreCounter.GetScores()}";
            _fpsInput.enabled = false;
            _mouseLook.enabled = false;
        }
    }
}