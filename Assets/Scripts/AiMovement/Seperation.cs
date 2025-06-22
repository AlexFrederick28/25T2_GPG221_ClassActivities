using UnityEditor.U2D;
using UnityEngine;

public class Seperation : MonoBehaviour
{
    [SerializeField] private Neighbours _Neighbours;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float maxNeighbourDistance;
    [SerializeField] private float speed;
    private Vector3 directionToTarget;

    private void FixedUpdate()
    {
        Seperate();
    }

    private void Seperate()
    {
        foreach (var neighbour in _Neighbours.neighbourEntity)
        {
            directionToTarget = (neighbour.position - transform.position).normalized; // getting target direction
            maxNeighbourDistance = -Vector3.Distance(transform.position, neighbour.position); // getting the distance as a negative (to move away)
            directionToTarget *= maxNeighbourDistance; // adds the direction and distance as one variable
        }
        if (_Neighbours.neighbourEntity.Count != 0)
        {
            directionToTarget /= _Neighbours.neighbourEntity.Count; // averages the directionToTarget variable
            rb.AddForce(directionToTarget * speed); // adds the average of forces and distances to the rigidbody
        }
        else
        {
            maxNeighbourDistance = 0;
        }

    }
}
