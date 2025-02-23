using System;
using Codebase.MessangerService;
using Codebase.UI.Screens.Hud;
using Codebase.UI.Screens.Pause;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Codebase.Input
{
    [RequireComponent(typeof(CharacterController))]
    public class FPSInput : MonoBehaviour, IListener
    {
        [SerializeField] private float _speed = 6.0f;
        [SerializeField] private float _gravity = -9.8f;
        [SerializeField] private float _jumpHeight = 3.0f;

        private CharacterController _charController;
        private Vector3 _velocity;
        private bool _isGrounded;
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
            _messengerService.Register(this);
            _charController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            _isGrounded = _charController.isGrounded;

            float moveX = UnityEngine.Input.GetAxis("Horizontal");
            float moveZ = UnityEngine.Input.GetAxis("Vertical");

            Vector3 move = transform.right * moveX + transform.forward * moveZ;

            move = move.normalized * _speed;

            if (_isGrounded)
            {
                _velocity.y = 0f;

                if (UnityEngine.Input.GetButtonDown("Jump"))
                {
                    _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
                }
            }

            _velocity.y += _gravity * Time.deltaTime;
            _charController.Move((move + _velocity) * Time.deltaTime);
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            Rigidbody rb = hit.collider.attachedRigidbody;

            if (rb != null && !rb.isKinematic)
            {
                Vector3 pushDir = hit.moveDirection;
                pushDir.y = 0;

                float pushForce = 5f;
                rb.AddForce(pushDir * pushForce, ForceMode.Impulse);
            }
        }

        private void OnDestroy()
        {
            _messengerService.Unregister(this);
        }

        public void Receive(object sender, object message)
        {
            if (message is TimerEndMessage)
            {
                enabled = false;
            }

            if (message is PauseMessage msg)
            {
                enabled = !msg.IsPaused;
            }
        }
    }
}