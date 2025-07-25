using Anthill.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForEnemy : AntAIState
{
    private Wander _wander;
    private MoveForward _moveForward;

    [Space]
    public Transform detectedTransform;

    [Space]
    [SerializeField] private bool canSee = true;
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

    [Space]
    public bool canDetectSound = true;
    [SerializeField] private SoundListener soundListener;
    [SerializeField] private float hearingRadius = 20f;

    public override void Enter()
    {
        base.Enter();

        soundListener.HeardSound_Event += OnHeardSound_Event;

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

        soundListener.HeardSound_Event -= OnHeardSound_Event;

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
        if (canSee)
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
                        GameObject objectHit = transformHit.collider.gameObject;
                        DetectEnemyTransform(objectHit);
                    }
                }

                dirTop = Vector3.zero;
                dirBot = Vector3.zero;
            }
        }
    }

    public void DetectEnemyTransform(GameObject hit)
    {
        detectedTransform = hit.GetComponentInParent<Transform>();
        GetComponentInParent<AIBeylbladeAttacker>().detectedEnemyTransform = detectedTransform;
    }

    private void OnHeardSound_Event()
    {
        Debug.Log("HEARD");
        if (canDetectSound)
        {
            Collider[] results = new Collider[10];

            Physics.OverlapSphereNonAlloc(transform.position, hearingRadius, results);

            foreach (Collider result in results)
            {
                if (result != null)
                {
                    if (result.gameObject == GetComponentInParent<AIBeylbladeAttacker>().gameObject)
                    {
                        continue;
                    }
                    else
                    {
                        DetectEnemyTransform(result.gameObject);
                    }
                }
            }

        }
    }
}
