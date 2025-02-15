using UnityEngine;

public class Player : MonoBehaviour
{
    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * 10f);
    }
}