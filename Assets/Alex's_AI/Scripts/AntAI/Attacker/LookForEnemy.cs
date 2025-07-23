using Anthill.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForEnemy : AntAIState
{
    private Wander _wander;
    private MoveForward _moveForward;

    public Transform detectedTransform;

    public Transform topVision;
    public Transform bottomVision;
    public float topVisionDirection;
    public float bottomVisionDirection;

    public float visionTickRate = 1f;
    public float visionMaxAngle = 100;
    public float visionLength = 50f;
    public int rays = 10;

    private float visionTimer;

    [SerializeField] private Vector3 dirTop = Vector3.zero;
    [SerializeField] private Vector3 dirBot = Vector3.zero;

    public override void Enter()
    {
        base.Enter();

        dirTop = Vector3.zero;
        dirBot = Vector3.zero;

        if (_wander == null)
        {
            _moveForward = GetComponent<MoveForward>();
            _wander = GetComponent<Wander>();
        }
        if (_wander.rb == null)
        {
            _moveForward.rb = GetComponentInParent<Rigidbody>();
            _wander.rb = GetComponentInParent<Rigidbody>();
        }
    }

    public override void Exit()
    {
        base.Exit();

        dirTop = Vector3.zero;
        dirBot = Vector3.zero;
    }

    public override void Execute(float aDeltaTime, float aTimeScale)
    {
        visionTimer += Time.deltaTime;

        if (visionTimer > visionTickRate)
        {
            ShootRaycasts();
            visionTimer = 0f;
        }
    }

    public void ShootRaycasts()
    {
        float currentAngle = visionMaxAngle / 2f;

        RaycastHit transformHit;

        for (int i = 0; i < rays; i++)
        {
            dirTop = Quaternion.Euler(topVisionDirection, currentAngle, 0) * transform.forward;
            dirBot = Quaternion.Euler(bottomVisionDirection, currentAngle, 0) * transform.forward;
            Debug.DrawRay(topVision.position, dirTop * visionLength, Color.green);
            Debug.DrawRay(bottomVision.position, dirBot * visionLength, Color.green);

            float spreadAngle = visionMaxAngle / (rays - 1);
            currentAngle += spreadAngle;

            if (Physics.Raycast(topVision.position, dirTop, out transformHit, visionLength) && Physics.Raycast(bottomVision.position, dirBot, out transformHit, visionLength))
            {
                if (transformHit.transform.GetComponentInParent<IEnergyUser>() != null)
                {
                    DetectEnemyTransform(transformHit);
                }
            }

            Debug.Log(dirTop);
            dirTop = Vector3.zero;
            dirBot = Vector3.zero;
        }
    }

    public void DetectEnemyTransform(RaycastHit hit)
    {
        detectedTransform = hit.collider.GetComponentInParent<Transform>();
        GetComponentInParent<AIBeylbladeAttacker>().detectedEnemyTransform = detectedTransform;
    }
}
