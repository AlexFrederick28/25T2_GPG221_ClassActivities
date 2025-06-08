using System;
using UnityEngine;
using UnityEngine.AI;

public class PathFinder : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;

    [SerializeField] private NavMeshPath path;

    //[SerializeField] private int pathIndex = 0; // turn towards >>

    Vector3[] pathCorners;
    [SerializeField] private int cornerIndex = 0; // This keeps track of the next corner you want to go to

    [SerializeField] private float distanceToCorner;

    // Update is called once per frame
    void Update()
    {
        path = new NavMeshPath();

        if (NavMesh.CalculatePath(transform.position, targetTransform.position, int.MaxValue, path))
        {

        }
    }
    void FixedUpdate()
    {
        //distanceToCorner = path.corners[cornerIndex].magnitude;
       
        // See if we are close to the corner
        if (path != null)
        {
            //distanceToCorner = Vector3.Magnitude(path.corners[cornerIndex]);
            Debug.Log("Distance to the next point is " + distanceToCorner);
        }
        if (cornerIndex > path.corners.Length)
        {
            cornerIndex = 0;
        }
        // if Vector3.Distance from NPC to pathCorners[index] < 1f
        // 	  increase cornerIndex
        // 	  set TurnTowards target to pathCorners[index] 
    }

    private void OnDrawGizmos()
    {
        Vector3 lastPos = Vector3.zero;

        if (path != null)
        {
            for (var index = 0; index < path.corners.Length; index++)
            {
                var pathCorner = path.corners[index];

                if (index != 0)
                {
                    Gizmos.DrawLine(lastPos, pathCorner);
                }
                lastPos = pathCorner;
            }
        }
    }
}
