using UnityEngine;

public class Avoid : MonoBehaviour
{
    public Rigidbody rb;
    public float turnSpeed;
    public float distance;
    public LayerMask mask;
    
    private void FixedUpdate()
    {
        bool raycastHitSomething = Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, distance);

        if (Physics.Raycast(transform.position, transform.forward, distance, mask))
        {
            //Debug.Log("Hit " + raycastHitSomething);

            rb.AddTorque(0, turnSpeed, 0);
        }

    }
}
