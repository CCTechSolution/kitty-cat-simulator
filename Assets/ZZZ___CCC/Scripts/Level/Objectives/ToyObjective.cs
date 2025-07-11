using System.Collections.Generic;
using UnityEngine;

public class ToyObjective : BaseObjective
{

    [SerializeField] GameObject[] IndiacatorsGameObjects;
    protected override void RegisterEvent()
    {
        Granny_Detection.OnToyHitGranny += Success;
        ToggleIndicators(IndiacatorsGameObjects, true);
    }

    protected override void UnregisterEvent()
    {
        Granny_Detection.OnToyHitGranny -= Success;
    }

    private void OnDisable()
    {
        ToggleIndicators(IndiacatorsGameObjects, false);
    }
}
