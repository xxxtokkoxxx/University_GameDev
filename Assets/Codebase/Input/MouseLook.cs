using System;
using Codebase.MessangerService;
using Codebase.UI.Screens.Hud;
using Codebase.UI.Screens.Pause;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Codebase.Input
{
    public class MouseLook : MonoBehaviour, IListener
    {
        [SerializeField] private Transform _playerBody;
        [SerializeField] private float _sensitivityHor = 100f;
        [SerializeField] private float _sensitivityVert = 100f;
        [SerializeField] private float _minimumVert = -90f;
        [SerializeField] private float _maximumVert = 90f;

        private float rotationX = 0f;
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
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            float mouseX = UnityEngine.Input.GetAxis("Mouse X") * _sensitivityHor * Time.deltaTime;
            float mouseY = UnityEngine.Input.GetAxis("Mouse Y") * _sensitivityVert * Time.deltaTime;

            _playerBody.Rotate(Vector3.up * mouseX);

            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, _minimumVert, _maximumVert);
            transform.localRotation = Quaternion.Euler(rotationX, transform.localRotation.eulerAngles.y, 0f);
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