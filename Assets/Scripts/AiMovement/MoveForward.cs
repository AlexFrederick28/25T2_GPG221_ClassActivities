using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private float speed = 100;

    private void FixedUpdate()
    {
        rb.AddRelativeForce(0,0,speed, ForceMode.Acceleration);
    }
}
