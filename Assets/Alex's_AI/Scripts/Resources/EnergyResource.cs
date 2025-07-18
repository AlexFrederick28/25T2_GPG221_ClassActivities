using UnityEngine;

public class EnergyResource : MonoBehaviour
{
    public int energyAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IEnergyUser>() != null)
        {
            other.gameObject.GetComponent<IEnergyUser>().AddEnergy(energyAmount);
        }
    }
}
