using TMPro;
using UnityEngine;

namespace Codebase.UI.Screens.Hud
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        private int _scores;

        public void AddScore(int scoreToAdd)
        {
            _scores += scoreToAdd;
            _scoreText.text = $"Scores: {_scores.ToString()}";
        }

        public int GetScores()
        {
            return _scores;
        }

        public void Reset()
        {
            _scores = 0;
            _scoreText.text = $"Scores: {_scores.ToString()}";
        }
    }
}