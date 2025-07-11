using System.Collections.Generic;
using UnityEngine;

public class FruitsObjective : BaseObjective
{

    [SerializeField] GameObject[] IndiacatorsGameObjects;

    protected override void RegisterEvent()
    {
        Granny_Detection.OnFruitHitGranny += Success;
        ToggleIndicators(IndiacatorsGameObjects, true);
    }

    protected override void UnregisterEvent()
    {
        Granny_Detection.OnFruitHitGranny -= Success;
    }

    private void OnDisable()
    {
        ToggleIndicators(IndiacatorsGameObjects, false);
    }
}
