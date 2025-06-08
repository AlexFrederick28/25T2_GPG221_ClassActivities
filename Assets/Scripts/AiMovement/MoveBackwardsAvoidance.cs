using UnityEngine;

public class MoveBackwardsAvoidance : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float detectionDistance;
    private Ray raycast;
    [SerializeField] private string objectDetected;

    private void FixedUpdate()
    {
        raycast = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(raycast, out RaycastHit hit, detectionDistance))
        {
            rb.AddRelativeForce(0, 0, -speed, ForceMode.Acceleration);
            objectDetected = hit.collider.name;
        }
    }
}
