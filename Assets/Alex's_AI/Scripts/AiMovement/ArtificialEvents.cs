using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArtificialEvents : MonoBehaviour
{
    public UnityEvent chaseTarget;

    [SerializeField] private bool startChase = false;
    [SerializeField] private List<GameObject> spawnedAIs;

    // add all ais that spawn to a list
    // add a death event to remove ais after destroying

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void Chasing()
    {
        if (startChase)
        {
            //GetComponent<TurnTowards>().
        }
    }
}
