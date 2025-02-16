using Codebase.UI.HUD;
using DG.Tweening;
using UnityEngine;

namespace Codebase.Environment
{
    public class PickableItem : MonoBehaviour
    {
        [SerializeField] private ScoreCounter _scoreCounter;
        [SerializeField] private float _rotationSpeed = 90f;

        private void Start()
        {
            transform.DORotate(new Vector3(0, 360, 0), _rotationSpeed, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Incremental)
                .SetEase(Ease.Linear);
        }

        private void OnTriggerEnter(Collider other)
        {
            _scoreCounter.AddScore(1);
            gameObject.SetActive(false);
        }
    }
}