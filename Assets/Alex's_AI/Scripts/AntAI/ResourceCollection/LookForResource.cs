using UnityEngine;
using Anthill.AI;

public class LookForResource : AntAIState
{
    [SerializeField] private Collider resourceDetector;
    [SerializeField] private float detectorMaxRadius;
    [SerializeField] private float detectionRadiusSpeed;
    [SerializeField] private float detectorDefaultRadius;

    private bool enlargeDetectorRadius = false;

    public override void Enter()
    {
        base.Enter();

        //resourceDetector = GetComponentInParent<AIResourceGatherer>().detectorCollider;
        resourceDetector = GetComponentInParent<ResourceDetection>().detectorCollider;
        resourceDetector.GetComponent<SphereCollider>().radius = detectorDefaultRadius;
    }

    public override void Exit()
    {
        base.Exit();

        resourceDetector.GetComponent<SphereCollider>().radius = detectorDefaultRadius;
    }

    public override void Execute(float aDeltaTime, float aTimeScale)
    {
        base.Execute(aDeltaTime, aTimeScale);

        WidenDetectionArea(resourceDetector);
    }

    private void WidenDetectionArea(Collider _resourceDetector)
    {
        if (_resourceDetector.GetComponent<SphereCollider>().radius == detectorDefaultRadius)
        {
            enlargeDetectorRadius = true;
        }
        if (enlargeDetectorRadius)
        {
            if (_resourceDetector.GetComponent<SphereCollider>().radius < detectorMaxRadius)
            {
                _resourceDetector.GetComponent<SphereCollider>().radius += 1 * detectionRadiusSpeed * Time.deltaTime;
            }
            if (_resourceDetector.GetComponent<SphereCollider>().radius > detectorMaxRadius)
            {
                enlargeDetectorRadius = false;
            }
        }
    }
}

