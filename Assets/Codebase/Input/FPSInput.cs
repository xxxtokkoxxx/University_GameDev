using UnityEngine;

namespace Codebase.Input
{
    [RequireComponent(typeof(CharacterController))]
    public class FPSInput : MonoBehaviour
    {
        [SerializeField] private float _speed = 6.0f;
        [SerializeField] private float _gravity = -9.8f;
        [SerializeField] private float _jumpHeight = 3.0f;

        private CharacterController _charController;
        private Vector3 _velocity;
        private bool _isGrounded;

        private void Start()
        {
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
    }
}