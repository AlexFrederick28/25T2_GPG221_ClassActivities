using UnityEngine;

public class MoveBackwards : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private float speed;

    private void FixedUpdate()
    {
        rb.AddRelativeForce(0, 0, -speed, ForceMode.Acceleration);
    }
}
