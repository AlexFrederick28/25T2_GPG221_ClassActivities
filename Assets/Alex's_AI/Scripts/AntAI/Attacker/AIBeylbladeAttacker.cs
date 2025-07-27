using Anthill.AI;
using TMPro.EditorUtilities;
using UnityEngine;

/// <summary>
/// A specific set of conditions for an attacker AI
/// </summary>
public class AIBeylbladeAttacker : AntAIState, ISense, IEnergyUser
{
    public GameObject baseModel;
    public GameObject attackModel;
    public Transform detectedEnemyTransform;
    public int attackEnemyCost = 50;

    public bool isAtDistance = false;
    public bool hitEnemy = false;

    public float maxDistanceToAttack;
    public float minDistanceToAttack;

    public bool SeeEnemy()
    {
        if (detectedEnemyTransform != null)
        {
            return detectedEnemyTransform;
        }
        else
        {
            return false;
        }
    }
    public bool HasEnergy()
    {
        return GetComponent<EnergySupply>()._currentEnergy >= attackEnemyCost;
    }
    public bool InAttackPosition()
    {
        if (SeeEnemy() && HasEnergy())
        {
            return isAtDistance;
        }
        else
        {
            return false;
        }
    }
    public bool HitEnemy()
    {
        if (InAttackPosition())
        {
            return hitEnemy;
        }
        else
        {
            return false;
        }
    }
    public bool SeeEnergy()
    {
        return (GetComponent<ResourceDetection>().detectedEnergyTransform);
    }
    public bool AtEnergy()
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
    public bool FullEnergy()
    {
        if (GetComponentInParent<EnergySupply>()._currentEnergy == 200)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CollectConditions(AntAIAgent aAgent, AntAICondition aWorldState)
    {
        aWorldState.Set(BeybladeAttacker.SeeEnemy, SeeEnemy());
        aWorldState.Set(BeybladeAttacker.HasEnergy, HasEnergy());
        aWorldState.Set(BeybladeAttacker.InAttackPosition, InAttackPosition());
        aWorldState.Set(BeybladeAttacker.HitEnemy, HitEnemy());
        aWorldState.Set(BeybladeAttacker.SeeEnergy, SeeEnergy());
        aWorldState.Set(BeybladeAttacker.AtEnergy, AtEnergy());
        aWorldState.Set(BeybladeAttacker.FullEnergy, FullEnergy());
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
