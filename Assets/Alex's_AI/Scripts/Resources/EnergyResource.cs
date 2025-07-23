using UnityEngine;

public class EnergyResource : MonoBehaviour
{
    public int energyAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<IEnergyUser>() != null && other.gameObject.GetComponentInParent<ResourceCollector>().collectorCollider.enabled)
        {
            other.gameObject.GetComponentInParent<IEnergyUser>().AddEnergy(energyAmount);

            Destroy(gameObject);
        }
    }
}
