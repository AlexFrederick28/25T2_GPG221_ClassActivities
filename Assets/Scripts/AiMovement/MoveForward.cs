using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] protected float speed;

    private void FixedUpdate()
    {
        rb.AddRelativeForce(0,0,speed, ForceMode.Acceleration);
    }
}
