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

        GetComponentInParent<ResourceCollector>().collectorCollider.enabled = false;
        GetComponentInParent<ResourceCollector>().collectionLight.enabled = false;
    }

    private IEnumerator EnableCollider_C()
    {
        if (GetComponentInParent<ResourceDetection>().detectedEnergyTransform != null)
        {
            if (GetComponentInParent<AIResourceGatherer>() != null)
            {
                if (GetComponentInParent<AIResourceGatherer>()._atResource())
                {
                    GetComponentInParent<ResourceCollector>().collectionLight.enabled = true;
                }
            }
            else if (GetComponentInParent<AIBeylbladeAttacker>() != null)
            {
                if (GetComponentInParent<AIBeylbladeAttacker>().AtEnergy())
                {
                    GetComponentInParent<ResourceCollector>().collectionLight.enabled = true;
                }
            }

            yield return new WaitForSeconds(collectingTime);

            GetComponentInParent<ResourceCollector>().collectorCollider.enabled = true;
        }
    }

}

