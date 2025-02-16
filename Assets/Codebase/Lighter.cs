using UnityEngine;

namespace Codebase
{
    public class Lighter : MonoBehaviour
    {
        [SerializeField] private Light _pointLight;
        [SerializeField] private GameObject _floor;
    
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject == _floor)
            {
                _pointLight.enabled = true;
                _pointLight.intensity = 5;
            }
        }
    }
}