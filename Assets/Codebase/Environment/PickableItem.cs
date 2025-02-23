using Codebase.MessangerService;
using DG.Tweening;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Codebase.Environment
{
    public class PickableItem : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 90f;

        private IMessengerService _messengerService;

        [Inject]
        public void Inject(IMessengerService messengerService)
        {
            _messengerService = messengerService;
        }

        private void Awake()
        {
            IObjectResolver container = FindFirstObjectByType<LifetimeScope>()?.Container;
            container?.Inject(this);
        }

        private void Start()
        {
            transform.DORotate(new Vector3(0, 360, 0), _rotationSpeed, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Incremental)
                .SetEase(Ease.Linear);
        }

        private void OnTriggerEnter(Collider other)
        {
            _messengerService.Send(this, new PickCoinMessage());
            gameObject.SetActive(false);
        }
    }
}