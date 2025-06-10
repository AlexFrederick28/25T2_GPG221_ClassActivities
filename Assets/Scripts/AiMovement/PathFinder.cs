using System;
using UnityEngine;
using UnityEngine.AI;

public class PathFinder : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private NavMeshPath path;
    
    [SerializeField] private int cornerIndex; // This keeps track of the next corner you want to go to
    [SerializeField] private float magnitudeToCorner;
    public Vector3 currentPath;

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        path = new NavMeshPath();

        if (NavMesh.CalculatePath(transform.position, targetTransform.position, int.MaxValue, path))
        {

        }

        //distanceToCorner = path.corners[cornerIndex].magnitude;

        // See if we are close to the corner
        if (path != null)
        {
            currentPath = path.corners[cornerIndex]; // keeps track of the current selected path corner vector
            
            magnitudeToCorner = Vector3.Distance(transform.position, currentPath); // shows the distance to the next corner
            
            if (cornerIndex > path.corners.Length)
            {
                cornerIndex = 0;
            }
        }
        if (cornerIndex > path.corners.Length)
        {
            cornerIndex = 0;
        }
        
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
