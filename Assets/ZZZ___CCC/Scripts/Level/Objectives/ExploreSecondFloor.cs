using System.Collections.Generic;
using UnityEngine;

public class ExploreSecondFloor : BaseObjective
{
    [SerializeField]
    CollidersForEvents[] allCollidersForEvents;
    [SerializeField] GameObject[] IndiacatorsGameObjects;
    protected override void RegisterEvent()
    {
        CollidersForEvents.OnEnterCollider+= Success;
        SetWayPoints.Instance.ToSecondFloorHalf();
        CatGranPos.Instance.InSecondFloor();
        ToggleIndicators(IndiacatorsGameObjects, true);
        allCollidersForEvents = FindObjectsByType<CollidersForEvents>(FindObjectsInactive.Include,FindObjectsSortMode.None);
    }

    protected override void UnregisterEvent()
    {
        CollidersForEvents.OnEnterCollider -= Success;
       
    }

    protected override void OnRetry()
    {
        foreach (var col in allCollidersForEvents)
        {
            col.canSendCall = true;
        }
    }

    private void OnDisable()
    {
        ToggleIndicators(IndiacatorsGameObjects, false);
    }
}
