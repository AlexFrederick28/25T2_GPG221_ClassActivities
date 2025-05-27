using UnityEngine;

public class Avoid : MonoBehaviour
{
    public Rigidbody rb;
    public float turnSpeed = 10f;
    public float distance = 3f;
    
    private void FixedUpdate()
    {
        bool raycastHitSomething = Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, distance);

        if (Physics.Raycast(transform.position, transform.forward, distance))
        {
            Debug.Log("Hit " + raycastHitSomething);

            rb.AddTorque(0, turnSpeed, 0);
        }

    }
}
