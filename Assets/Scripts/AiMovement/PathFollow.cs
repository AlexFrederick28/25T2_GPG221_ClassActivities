using UnityEngine;
using UnityEngine.AI;

public class PathFollow : MonoBehaviour
{
    [SerializeField] private int pathIndex = 0; // turn towards >>

    [SerializeField] private NavMeshPath path;

    Vector3[] pathCorners;
    int cornerIndex = 0; // This keeps track of the next corner you want to go to

    void FixedUpdate()
    {
        // See if we are close to the corner
        // if Vector3.Distance from NPC to pathCorners[index] < 1f
        // 	  increase cornerIndex
        // 	  set TurnTowards target to pathCorners[index] 
    }

}
