
using System.Collections.Generic;
using UnityEngine;

public class CollectYarn_Obj : BaseObjective
{

    [SerializeField] GameObject[] IndiacatorsGameObjects;
    protected override void RegisterEvent()
    {
        Granny_Detection.OnBottleHitGranny += Success;
        ToggleIndicators(IndiacatorsGameObjects, true);
    }

    protected override void UnregisterEvent()
    {
        Granny_Detection.OnBottleHitGranny -= Success;
        
    }
    private void OnDisable()
    {
        ToggleIndicators(IndiacatorsGameObjects, false);
    }
}
