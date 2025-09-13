using System.Collections.Generic;
using UnityEngine;

public class ThrowBooks : BaseObjective
{

    [SerializeField] GameObject[] IndiacatorsGameObjects;
    protected override void RegisterEvent()
    {        
        Granny_Detection.OnBookHitGranny += Success;        
        ToggleIndicators(IndiacatorsGameObjects, true);
    }

    protected override void UnregisterEvent()
    {
        Granny_Detection.OnBookHitGranny -= Success;
        
    }
    private void OnDisable()
    {
        ToggleIndicators(IndiacatorsGameObjects, false);
    }
}
