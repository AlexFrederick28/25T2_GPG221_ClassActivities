using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class VisionSystem : MonoBehaviour
{
    public float maxAngle = 100;
    public int rays = 10;

    public Transform sphereDrawPosition;
    public float sphereRadius = 1f;

    private void FixedUpdate() // TODO: ensure the raycasts only appear when needed x amount of times
    {
        AreaOfVision();

        float currentAngle = -maxAngle / 2f;

        for (int i = 0; i < rays; i++)
        {
            Vector3 dir = Quaternion.Euler(0, currentAngle, 0) * transform.forward;
            Debug.DrawRay(transform.position, dir * 10f, Color.green);

            float spreadAngle = maxAngle / (rays - 1);
            currentAngle += spreadAngle;
        }
    }

    private void AreaOfVision() // check to see if something is in the area of this object to need to see
    {
        Collider[] hitColliders = Physics.OverlapSphere(sphereDrawPosition.position, sphereRadius);

        foreach (Collider collider in hitColliders)
        {
            Debug.Log("HIT: " + collider.gameObject.name);
        }

    }

}
