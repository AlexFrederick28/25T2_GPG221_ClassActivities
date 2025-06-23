using Unity.VisualScripting;
using UnityEngine;

public class Cohesion : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Neighbours _Neighbours;
    [SerializeField] private Rigidbody rb;
    [Space]
    [Header("Visual Representation Only")]
    [Tooltip("Varaible is read-only, no need to customise within the inspector")]
    [SerializeField] private float distance;
    [Space]
    [Header("Custom Values")]
    [Tooltip("The estimated MAX distance - keep vales that the calculated distance (shown above) does not exceed")]
    [SerializeField] private float maxNeighbourDistance;
    [Tooltip("Determines how harsh the force curve is")]
    [SerializeField] private float forceMultiplier;
    [Tooltip("What the maximum amount of force will be before cutting off")]
    [SerializeField] private float maxForce;
    [SerializeField] private AnimationCurve forceCurve;

    private Vector3 directionToTarget;
    private float speed;
    private float maxDistance;

    private void FixedUpdate()
    {
        Combine();
    }

    private void Combine()
    {
        // ensure the numbers reset to zero when out of range from neighbours
        if (_Neighbours.neighbourEntity.Count == 0)
        {
            distance = 0f;
            directionToTarget = Vector3.zero;
            speed = 0f;
            maxDistance = 0f;
        }

        if (_Neighbours.neighbourEntity.Count != 0)
        {
            // go through each neighbour and get the direction
            // get the distance between each and invert it using a max distance value
            // use the inverted distance with animation curve to add a gradual force
            // add the total direction and forces to rigidbody
            foreach (var neighbour in _Neighbours.neighbourEntity)
            {
                directionToTarget = (neighbour.position - transform.position).normalized; // direction
                distance = Vector3.Distance(neighbour.position, transform.position); // distance 
            }

            directionToTarget /= _Neighbours.neighbourEntity.Count;
            maxDistance = maxNeighbourDistance - distance;

            // if speed exceeds the max force, cut off
            if (speed < maxForce && distance > 4f)
            {
                speed += forceCurve.Evaluate(maxDistance) * forceMultiplier;
            }
            // if too close to the neighbour, remove speed
            if (distance < 4f)
            {
                speed = 0f;
            }

            rb.AddForce(directionToTarget * speed);
        }
    }
}
