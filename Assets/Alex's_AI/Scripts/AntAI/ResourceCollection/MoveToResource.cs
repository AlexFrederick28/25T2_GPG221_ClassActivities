using UnityEngine;
using Anthill.AI;

/// <summary>
/// AntAIState - used to move to a resource 
/// </summary>
public class MoveToResource : AntAIState
{
    private TurnTowards _turnTowards;

    public override void Execute(float aDeltaTime, float aTimeScale)
    {
        base.Execute(aDeltaTime, aTimeScale);

        TurnTowardsResource();
        MoveForward();
    }

    private void TurnTowardsResource()
    {
        if (_turnTowards == null)
        {
            _turnTowards = GetComponent<TurnTowards>();
        }

        _turnTowards.rb = GetComponentInParent<Rigidbody>();
        _turnTowards.targetObject = GetComponentInParent<ResourceDetection>().detectedEnergyTransform;
    }

    private void MoveForward()
    {
        if (gameObject.GetComponent<MoveForward>().rb == null)
        {
            gameObject.GetComponent<MoveForward>().rb = gameObject.GetComponentInParent<Rigidbody>();
        }
    }
}
