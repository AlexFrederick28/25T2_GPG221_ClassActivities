namespace Anthill.AI
{
    using UnityEngine;

    public class PlaceHolder : AntAIState, ISense
    {
        public bool seeResource;
        public bool HasResource;
        public bool AtResource;

        public void CollectConditions(AntAIAgent aAgent, AntAICondition aWorldState)
        {
            aWorldState.Set(GatherResource.HasResource, false);
        }
    }
}
