using UnityEngine;
using Anthill.AI;
using Unity.VisualScripting;

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

    [Tooltip("How close the AI has to be to the resource")]
    [SerializeField] private int pickupResourceDistance;

    public Transform detectedEnergyTransform;
    public Collider detectorCollider;
    public Collider collectorCollider;

    public void CollectConditions(AntAIAgent aAgent, AntAICondition aWorldState)
    {
        aWorldState.Set(GatherResource.SeeResource, _seeResource);
        aWorldState.Set(GatherResource.HasResource, _hasResource);
        aWorldState.Set(GatherResource.AtResource, _atResource);
    }

    private void Update()
    {
        FoundResource();
        AtResource();
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

    private void FoundResource()
    {
        if (detectedEnergyTransform != null)
        {
            _seeResource = true;

            detectorCollider.enabled = false;
        }
        else
        {
            _seeResource = false;

            detectorCollider.enabled = true;
        }
    }

    private void AtResource()
    {
        if (GetComponentInParent<AIResourceGatherer>().detectedEnergyTransform != null)
        {
            if (Vector3.Distance(transform.position, detectedEnergyTransform.position) < pickupResourceDistance)
            {
                _atResource = true;
            }
            else
            {
                _atResource = false;
            }
        }
    }
}

