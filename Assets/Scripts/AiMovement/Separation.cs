using System.ComponentModel;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Separation : MonoBehaviour
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
        Seperate();
    }

    private void Seperate()
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
                directionToTarget = (transform.position - neighbour.position).normalized; // direction
                distance = Vector3.Distance(transform.position, neighbour.position); // distance 
            }

            directionToTarget /= _Neighbours.neighbourEntity.Count;
            maxDistance = maxNeighbourDistance - distance;

            // if speed exceeds the max force, cut off
            if (speed < maxForce)
            {
                speed += forceCurve.Evaluate(maxDistance) * forceMultiplier;
            }

            rb.AddForce(directionToTarget * speed);
        }
    }

}
