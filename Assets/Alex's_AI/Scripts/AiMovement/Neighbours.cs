using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class Neighbours : MonoBehaviour
{
    public List<Transform> neighbourEntity;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger)
        {
            neighbourEntity.Add(other.transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.isTrigger)
        {
            neighbourEntity.Remove(other.transform);
        }
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            foreach (var entity in neighbourEntity)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawLine(transform.position, entity.transform.position);
            }
        }
    }


}
