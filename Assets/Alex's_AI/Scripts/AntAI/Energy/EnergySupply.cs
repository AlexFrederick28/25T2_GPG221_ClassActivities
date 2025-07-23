using UnityEngine;

public class EnergySupply : MonoBehaviour
{
    [SerializeField] private int currentEnergy;
    [Tooltip("How much energy it can potentially have")]
    [SerializeField] private int maxEnergyCap;

    public int _currentEnergy
    {
        get { return currentEnergy; }
        set
        {
            if (value > maxEnergyCap)
            {
                value = maxEnergyCap;
            }
            if (value < 0)
            {
                value = 0;
            }

            currentEnergy = value;
        }
    }
}
