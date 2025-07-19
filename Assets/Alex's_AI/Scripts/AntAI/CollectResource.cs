using UnityEngine;
using Anthill.AI;
using System.Collections;
using System.Collections.Generic;

public class CollectResource : AntAIState
{

    public float collectingTime;
    private bool atResource = false;

    public override void Execute(float aDeltaTime, float aTimeScale)
    {
        base.Execute(aDeltaTime, aTimeScale);

        StartCoroutine(EnableCollider_C());
    }

    public override void Exit()
    {
        base.Exit();

        GetComponentInParent<AIResourceGatherer>().collectorCollider.enabled = false;
    }

    private IEnumerator EnableCollider_C()
    {
        if (GetComponentInParent<AIResourceGatherer>()._atResource)
        {
            atResource = true;
        }
        if (atResource)
        {
            yield return new WaitForSeconds(collectingTime);

            GetComponentInParent<AIResourceGatherer>().collectorCollider.enabled = true;
        }
    }

}

