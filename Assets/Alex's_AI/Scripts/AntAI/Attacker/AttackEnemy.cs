using Anthill.AI;
using Unity.Mathematics;
using UnityEngine;

/// <summary>
/// Not moduralised! Specifically only works for the "AIBeybladeAttacker.cs" (bad code). Spins the objects model and sets an object to look at 
/// </summary>
public class AttackEnemy : AntAIState
{
    private MoveForward _moveForward;
    private TurnTowards _turnTowards;

    public float objectRotationSpeed;
    public float weaponRotationSpeed;

    public override void Execute(float aDeltaTime, float aTimeScale)
    {
        base.Execute(aDeltaTime, aTimeScale);

        SpinModel();
    }

    public override void Enter()
    {
        base.Enter();

        if (_moveForward == null)
        {
            _turnTowards = GetComponent<TurnTowards>();
            _moveForward = GetComponent<MoveForward>();
        }
        if (_moveForward.rb == null)
        {
            _turnTowards.rb = GetComponentInParent<Rigidbody>();
            _moveForward.rb = GetComponentInParent<Rigidbody>();
        }

        _turnTowards.targetObject = GetComponentInParent<AIBeylbladeAttacker>().detectedEnemyTransform;
    }

    public override void Exit()
    {
        base.Exit();

        GetComponentInParent<AIBeylbladeAttacker>().hitEnemy = false;
        GetComponentInParent<AIBeylbladeAttacker>().isAtDistance = false;
        GetComponentInParent<AIBeylbladeAttacker>().detectedEnemyTransform = null;
    }

    private void SpinModel()
    {
        GetComponentInParent<AIBeylbladeAttacker>().baseModel.transform.Rotate(Vector3.up * objectRotationSpeed * Time.deltaTime);
        GetComponentInParent<AIBeylbladeAttacker>().attackModel.transform.Rotate(Vector3.up * weaponRotationSpeed * Time.deltaTime);
    }
}
