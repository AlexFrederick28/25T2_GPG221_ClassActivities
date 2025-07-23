using UnityEngine;

public class ResourceDetection : MonoBehaviour
{

    [Tooltip("How close the AI has to be to the resource")]
    public int pickupResourceDistance;

    public Transform detectedEnergyTransform;
    public Collider detectorCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<EnergyResource>())
        {
            detectedEnergyTransform = other.transform;
        }
    }

}
