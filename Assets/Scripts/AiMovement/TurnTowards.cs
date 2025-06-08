using UnityEngine;

public class TurnTowards : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 2;
    [SerializeField] private Transform targetObject;
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private Rigidbody rb;


    //Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetDir;

        if (targetObject)
        {
            // Has a target gameobject
            targetDir = (targetObject.position - transform.position).normalized;
            float angle = Vector3.SignedAngle(transform.forward, targetDir, transform.up);
            rb.AddRelativeTorque(0, angle, 0);
        }
        else
        {
            targetPosition = GetComponent<PathFinder>().currentPath;

            // Just a raw position in the world (for pathfinding points)
            targetDir = (targetPosition - transform.position).normalized;
            float angle = Vector3.SignedAngle(transform.forward, targetDir, transform.up);
            rb.AddRelativeTorque(0, angle, 0);
        }

    }
}
