using Anthill.AI;
using Tanks;
using UnityEngine;

/// <summary>
/// Not moduralised! Specifically only works for "AIBeybladeAttacker.cs" (bad code). Moves this object to the attack position
/// </summary>
public class MoveToAttack : AntAIState
{
    private TurnTowards _turnTowards;
    private AIBeylbladeAttacker _aiBeyBladeAttacker;
    [SerializeField] private MoveForward _moveForward;
    [SerializeField] private MoveBackwards _moveBackwards;

    public bool atDistance = false;

    public override void Execute(float aDeltaTime, float aTimeScale)
    {
        base.Execute(aDeltaTime, aTimeScale);

        MoveToAttackPosition();
    }

    public override void Enter()
    {
        base.Enter();

        if (_turnTowards == null)
        {
            _aiBeyBladeAttacker = GetComponentInParent<AIBeylbladeAttacker>();
            _turnTowards = GetComponent<TurnTowards>();
        }
        if (_moveForward.rb == null)
        {
            _moveBackwards.rb = GetComponentInParent<Rigidbody>();
            _turnTowards.rb = GetComponentInParent<Rigidbody>();
            _moveForward.rb = GetComponentInParent<Rigidbody>();
        }

        _moveBackwards.enabled = false;
        _moveForward.enabled = false;
        _aiBeyBladeAttacker.isAtDistance = false;
    }

    public override void Exit()
    {
        base.Exit();

        _moveBackwards.enabled = false;
        _moveForward.enabled = false;
    }

    private void MoveToAttackPosition()
    {
        _turnTowards.targetObject = _aiBeyBladeAttacker.detectedEnemyTransform;

        if (Vector3.Distance(transform.position, _aiBeyBladeAttacker.detectedEnemyTransform.position) < _aiBeyBladeAttacker.minDistanceToAttack)
        {
            // move backward
            _moveForward.enabled = false;
            _moveBackwards.enabled = true;

            _aiBeyBladeAttacker.isAtDistance = false;
        }
        else if (Vector3.Distance(transform.position, _aiBeyBladeAttacker.detectedEnemyTransform.position) > _aiBeyBladeAttacker.maxDistanceToAttack)
        {
            // move forward
            _moveBackwards.enabled = false;
            _moveForward.enabled = true;

            _aiBeyBladeAttacker.isAtDistance = false;
        }
        else if (Vector3.Distance(transform.position, _aiBeyBladeAttacker.detectedEnemyTransform.position) < _aiBeyBladeAttacker.maxDistanceToAttack && Vector3.Distance(transform.position, _aiBeyBladeAttacker.detectedEnemyTransform.position) > _aiBeyBladeAttacker.minDistanceToAttack)
        {
            // dont move
            _moveBackwards.enabled = false;
            _moveForward.enabled = false;

            _aiBeyBladeAttacker.isAtDistance = true;
        }
    }

}
