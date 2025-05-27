using UnityEngine;

public class Wander : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private float amount = 1000f;

    private void FixedUpdate()
    {
        rb.AddTorque(0, Random.Range(-amount, amount), 0);
    }
}
