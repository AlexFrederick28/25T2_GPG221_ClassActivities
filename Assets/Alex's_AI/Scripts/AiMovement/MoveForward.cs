using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private float speed;

    private void FixedUpdate()
    {
        if (rb != null)
        {
            rb.AddRelativeForce(0, 0, speed, ForceMode.Acceleration);
        }
    }
}
