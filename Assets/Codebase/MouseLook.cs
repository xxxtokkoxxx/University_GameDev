using UnityEngine;

namespace Codebase
{
    public class MouseLook : MonoBehaviour
    {
        [SerializeField] private Transform _playerBody;
        [SerializeField] private float _sensitivityHor = 100f;
        [SerializeField] private float _sensitivityVert = 100f;
        [SerializeField] private float _minimumVert = -90f;
        [SerializeField] private float _maximumVert = 90f;

        private float rotationX = 0f;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * _sensitivityHor * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * _sensitivityVert * Time.deltaTime;

            _playerBody.Rotate(Vector3.up * mouseX);

            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, _minimumVert, _maximumVert);
            transform.localRotation = Quaternion.Euler(rotationX, transform.localRotation.eulerAngles.y, 0f);
        }
    }
}