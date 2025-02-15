using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private void Start()
    {
        transform.position = _player.position - Vector3.forward * 10f;
    }
}