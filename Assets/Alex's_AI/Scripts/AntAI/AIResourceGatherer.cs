using UnityEngine;
using Anthill.AI;
using Unity.VisualScripting;
using System.Collections;

public class AIResourceGatherer : AntAIState, ISense, IEnergyUser
{
   
    public bool _seeResource()
    {
        return (detectedEnergyTransform);
    }
    public bool _hasResource() // bool doesnt seem necessary, as the AI doesnt need to do anything once it has a resource yet... Energy is the resource anyway
    {
        return (false);
    }
    public bool _atResource()
    {
        if (detectedEnergyTransform != null)
        {
            return (Vector3.Distance(transform.position, detectedEnergyTransform.position) < pickupResourceDistance);
        }
        else
        {
            return false;
        }
    }

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

    public enum States { lookForResource, moveToResource, collectResource } // TODO: Get the states to activate the AI functions
    public States currentState; 

    [Tooltip("How close the AI has to be to the resource")]
    [SerializeField] private int pickupResourceDistance;

    public Transform detectedEnergyTransform;
    public Collider detectorCollider;
    public Collider collectorCollider;
    public Light collectionLight;

    public void CollectConditions(AntAIAgent aAgent, AntAICondition aWorldState)
    {
        aWorldState.Set(GatherResource.SeeResource, _seeResource());
        aWorldState.Set(GatherResource.HasResource, _hasResource());
        aWorldState.Set(GatherResource.AtResource, _atResource());
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

