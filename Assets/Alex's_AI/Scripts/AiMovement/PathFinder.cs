
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinder : MonoBehaviour
{
    [SerializeField] private List<Transform> targetTransformList;
    [SerializeField] private Transform targetTransform;
    [SerializeField] private NavMeshPath path;
    
    [SerializeField] private int cornerIndex; // This keeps track of the next corner you want to go to
    [SerializeField] private float magnitudeToCorner;
    [SerializeField] private float magnitudeTarget;
    public Vector3 currentPath;

    void FixedUpdate()
    {
        path = new NavMeshPath();

        if (NavMesh.CalculatePath(transform.position, targetTransform.position, int.MaxValue, path))
        {
            CalculatePath();
        }
        if (magnitudeTarget < 1.5f)
        {
            ChooseTarget();
        }
        if (targetTransform == null)
        {
            ChooseTarget();
        }

    }

    private void ChooseTarget()
    {
        int randNumb = Random.Range(0, targetTransformList.Count);
        targetTransform = targetTransformList[randNumb];
    }

    private void CalculatePath()
    {
        if (path != null)
        {
            currentPath = path.corners[cornerIndex]; // keeps track of the current selected path corner vector

            magnitudeToCorner = Vector3.Distance(transform.position, currentPath); // shows the distance to the next corner

            if (cornerIndex > path.corners.Length)
            {
                cornerIndex = 0;
            }

            magnitudeTarget = Vector3.Distance(transform.position, targetTransform.position);
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 lastPos = Vector3.zero;

        if (path != null && Application.isPlaying)
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
