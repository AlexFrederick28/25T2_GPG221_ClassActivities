using UnityEngine;
using Anthill.AI;
using Unity.VisualScripting;
using System.Collections;

public class AIResourceGatherer : AntAIState, ISense, IEnergyUser
{
    public bool _seeResource()
    {
        return (GetComponent<ResourceDetection>().detectedEnergyTransform);
    }
    public bool _hasResource() // bool doesnt seem necessary, as the AI doesnt need to do anything once it has a resource yet... Energy is the resource anyway
    {
        return (false);
    }
    public bool _atResource()
    {
        if (GetComponent<ResourceDetection>().detectedEnergyTransform != null)
        {
            return (Vector3.Distance(transform.position, GetComponent<ResourceDetection>().detectedEnergyTransform.position) < GetComponent<ResourceDetection>().pickupResourceDistance);
        }
        else
        {
            return false;
        }
    }

    public enum States { lookForResource, moveToResource, collectResource } // TODO: Get the states to activate the AI functions
    public States currentState; 

    public void CollectConditions(AntAIAgent aAgent, AntAICondition aWorldState)
    {
        aWorldState.Set(GatherResource.SeeResource, _seeResource());
        aWorldState.Set(GatherResource.HasResource, _hasResource());
        aWorldState.Set(GatherResource.AtResource, _atResource());
    }

    public void AddEnergy(int amount)
    {
        GetComponentInParent<EnergySupply>()._currentEnergy += amount;
    }

    public void RemoveEnergy(int amount)
    {
        GetComponentInParent<EnergySupply>()._currentEnergy -= amount;
    }
}

