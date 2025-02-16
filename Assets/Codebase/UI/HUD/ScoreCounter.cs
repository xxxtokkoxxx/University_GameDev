using TMPro;
using UnityEngine;

namespace Codebase.UI.HUD
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
    }
}