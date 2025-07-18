using UnityEngine;
using Anthill.AI;

public class AIResourceGatherer : AntAIState, ISense, IEnergyUser
{
    public bool _seeResource;
    public bool _hasResource;
    public bool _atResource;

    [SerializeField] private int currentEnergy;
    
    public int _currentEnergy
    {
        get { return currentEnergy; }
        set
        {
            if (value > 200)
            {
                value = 200;
            }
            if (value < 0)
            {
                value = 0;
            }

            currentEnergy = value;
        }
    }

    public Transform detectedEnergyTransform;

    public void CollectConditions(AntAIAgent aAgent, AntAICondition aWorldState)
    {
        aWorldState.Set(GatherResource.SeeResource, _seeResource);
        aWorldState.Set(GatherResource.HasResource, _hasResource);
        aWorldState.Set(GatherResource.AtResource, _atResource);
    }

    public void AddEnergy(int amount)
    {
        _currentEnergy += amount;
    }

    public void RemoveEnergy(int amount)
    {
        _currentEnergy -= amount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<EnergyResource>())
        {
            detectedEnergyTransform = other.transform;
        }
    }
}

