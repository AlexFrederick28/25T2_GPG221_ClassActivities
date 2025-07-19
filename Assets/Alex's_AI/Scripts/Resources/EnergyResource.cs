using UnityEngine;

public class EnergyResource : MonoBehaviour
{
    public int energyAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IEnergyUser>() != null)
        {
            other.gameObject.GetComponent<IEnergyUser>().AddEnergy(energyAmount);

            Destroy(gameObject);
        }
        else if (other.gameObject.GetComponentInParent<IEnergyUser>() != null && other.gameObject.GetComponentInParent<AIResourceGatherer>()._atResource)
        {
            other.gameObject.GetComponentInParent<IEnergyUser>().AddEnergy(energyAmount);

            Destroy(gameObject);
        }
    }
}
