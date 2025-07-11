using System.Collections.Generic;
using UnityEngine;

public class FramesObjective : BaseObjective
{

    [SerializeField] GameObject[] IndiacatorsGameObjects;
    protected override void RegisterEvent()
    {
        Granny_Detection.OnFramesHitGranny += Success;
        SetWayPoints.Instance.ToSecondFloorHalf();
        CatGranPos.Instance.InSecondFloor();
        ToggleIndicators(IndiacatorsGameObjects, true);
    }

    protected override void UnregisterEvent()
    {
        Granny_Detection.OnFramesHitGranny -= Success;
        
    }

    private void OnDisable()
    {
        ToggleIndicators(IndiacatorsGameObjects, false);
    }
}
