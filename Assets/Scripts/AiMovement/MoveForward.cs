using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;

    private void FixedUpdate()
    {
        rb.AddRelativeForce(0,0,speed, ForceMode.Acceleration);
    }
}
